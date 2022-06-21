namespace Becerra.HexGrid
{
    using Becerra.HexGrid.Coordinates;
    using Becerra.HexGrid.Factories;
    using System.Collections.Generic;
    using UnityEngine;

#if UNITY_EDITOR

    using UnityEditor;
    using Sirenix.OdinInspector;

#endif

    public class HexGrid : MonoBehaviour
    {
        /// <summary>
        /// Size of the grid, representing rings from the center.
        /// </summary>
        public int Size = 3;

        /// <summary>
        /// Size of the tiles in the grid.
        /// </summary>
        public float TileSize = 1f;

        /// <summary>
        /// Collection of tiles in the grid indexed by their cube coordinate.
        /// </summary>
        private Dictionary<CubeCoordinates, IHexTile> tiles;

        /// <summary>
        /// Factory to create new tiles in the grid.
        /// Attach one of the implementations of <see cref="IHexTileFactory"/> to
        /// the same game object.
        /// </summary>
        private IHexTileFactory tilesFactory;

        /// <summary>
        /// Wether a cell in the grid is highlighted or not.
        /// </summary>
        private bool isCellHighlighted;

        /// <summary>
        /// Coordindates of the that's currently highlighted.
        /// </summary>
        private CubeCoordinates highlightedCellPosition;

        /// <summary>
        /// Horizontal size of a tile.
        /// </summary>
        private float tileWidth;

        /// <summary>
        /// Vertical size of a tile.
        /// </summary>
        private float tileHeight;

        /// <summary>
        /// Finds all tiles in range of a given pivot tile.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static List<CubeCoordinates> FindPositionsOnRange(CubeCoordinates center, int range)
        {
            var result = new List<CubeCoordinates>();

            for (int x = -range; x <= range; x++)
            {
                for (int y = -range; y <= range; y++)
                {
                    for (int z = -range; z <= range; z++)
                    {
                        if (x + y + z == 0)
                        {
                            result.Add(new CubeCoordinates(x, y, z));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Initializes the hex grid to be used.
        /// </summary>
        public void Initialize()
        {
            this.tilesFactory = this.gameObject.GetComponent<IHexTileFactory>();
        }

        /// <summary>
        /// Creates a new grid
        /// </summary>
        public void Create()
        {
            this.tiles = new Dictionary<CubeCoordinates, IHexTile>();
            this.tileWidth = HexTile.CalculateWidth(this.TileSize);
            this.tileHeight = HexTile.CalculateHeight(this.TileSize);

            var centerTile = CreateTile(new CubeCoordinates(0, 0, 0));

            RegisterTile(centerTile);

            if (this.Size > 1)
            {
                var generatedTiles = new List<IHexTile>();
                var edgeTiles = new List<IHexTile>();

                edgeTiles.AddRange(CreateNeighbors(centerTile));

                for (int ringIndex = 2; ringIndex < this.Size; ringIndex++)
                {
                    foreach (var tile in edgeTiles)
                    {
                        generatedTiles.AddRange(CreateNeighbors(tile));
                    }

                    edgeTiles.Clear();
                    edgeTiles.AddRange(generatedTiles);
                }
            }
        }

        /// <summary>
        /// Gets the tile at the given position.
        /// </summary>
        /// <param name="cubePosition">Position of the tile in cube coordinates.</param>
        /// <returns>Tile in the grid position, or null if there is no tile.</returns>
        public IHexTile GetTile(CubeCoordinates cubePosition)
        {
            if (HasTile(cubePosition) == false) return null;

            return this.tiles[cubePosition];
        }

        /// <summary>
        /// Wether the grid has a tile in the given position or not.
        /// </summary>
        /// <param name="cubePosition">Position in cube coordinates to check.</param>
        /// <returns>True if the grid has a tile registered at that position, false otherwise.</returns>
        public bool HasTile(CubeCoordinates cubePosition)
        {
            return this.tiles != null && this.tiles.ContainsKey(cubePosition);
        }

        /// <summary>
        /// Converts a world position into a grid position.
        /// </summary>
        /// <param name="worldPosition">Position in world coordinates.</param>
        /// <returns>Position in grid coordinates.</returns>
        public CubeCoordinates WorldToGridPosition(Vector3 worldPosition)
        {
            return CoordinatesConversor.WorldToCube(worldPosition, this.tileWidth, this.tileHeight);
        }

        /// <summary>
        /// Highlights a tile in the grid.
        /// </summary>
        /// <param name="cubePosition">Cube position of the tile to highlight.</param>
        public void HighlightTile(CubeCoordinates cubePosition)
        {
            this.isCellHighlighted = true;
            this.highlightedCellPosition = cubePosition;
        }

        /// <summary>
        /// Stops hilighting the current highlighted tile.
        /// </summary>
        public void StopTileHighlight()
        {
            this.isCellHighlighted = false;
        }

        /// <summary>
        /// Find all tiles in range.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public List<IHexTile> FindTilesInRange(CubeCoordinates center, int range)
        {
            var positions = FindPositionsOnRange(center, range);
            var result = new List<IHexTile>();

            foreach (var position in positions)
            {
                var tile = GetTile(position);

                if (tile != null)
                {
                    result.Add(tile);
                }
            }

            return result;
        }

        /// <summary>
        /// Creates a new tile suited to be used in the grid.
        /// </summary>
        /// <param name="cubePosition">Position inside the grid where the tile will be placed.</param>
        /// <returns>Generated tile, or null if there was a problem.</returns>
        private IHexTile CreateTile(CubeCoordinates cubePosition)
        {
            if (this.tilesFactory == null)
            {
                Debug.LogError($"No tile factory attached to {this.gameObject.name}, unable to create new tiles.");
                return null;
            }

            return this.tilesFactory.CreateHexTile(cubePosition, this.TileSize);
        }

        /// <summary>
        /// Registers a tile in the hex grid.
        /// If there is already a tile in that position, it won't be registered.
        /// </summary>
        /// <param name="tile">Tile to register.</param>
        /// <returns>True if the tile registered, false otherwise</returns>
        private bool RegisterTile(IHexTile tile)
        {
            if (tile == null) return false;
            if (this.tiles.ContainsKey(tile.CubePosition)) return false;

            this.tiles.Add(tile.CubePosition, tile);

            return true;
        }

        /// <summary>
        /// Create all neighbors of the given tile.
        /// </summary>
        /// <param name="tile">Tile to generate neighbors from.</param>
        /// <returns>List of all neighbors generated. If a tile was already registered in the grid, it won't be returned here.</returns>
        private IEnumerable<IHexTile> CreateNeighbors(IHexTile tile)
        {
            var neighbors = new List<IHexTile>();

            for (int i = 0; i < tile.NeighborsCount; i++)
            {
                var neighborPosition = tile.GetNeighborPosition(i);

                if (this.HasTile(neighborPosition)) continue;

                var neighborTile = CreateTile(neighborPosition);

                if (neighborTile == null) continue;

                RegisterTile(neighborTile);
                neighbors.Add(neighborTile);
            }

            return neighbors;
        }

#if UNITY_EDITOR

        [SerializeField] private bool showGrid;
        private Vector3 cursorWorldPosition;

        [Button]
        private void CreateTestGrid()
        {
            Initialize();
            Create();
        }

        /// <summary>
        /// Draws the tiles of the grid when the game object is selected in the scene.
        /// </summary>
        private void OnDrawGizmos()
        {
            if (this.showGrid == false) return;
            if (this.tiles == null) return;

            foreach (var tile in this.tiles.Values)
            {
                DrawTileGizmo(tile, Color.white * 0.5f);
            }

            if (this.isCellHighlighted)
            {
                var tile = this.GetTile(this.highlightedCellPosition);

                if (tile != null)
                {
                    DrawTileGizmo(tile, Color.green);
                }
            }

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.cursorWorldPosition, 0.3f);
        }

        /// <summary>
        /// Draws the gizmo of a tile.
        /// </summary>
        /// <param name="tile"></param>
        private void DrawTileGizmo(IHexTile tile, Color color)
        {
            Gizmos.color = color;

            for (int cornerIndex = 0; cornerIndex < tile.CornersCount; cornerIndex++)
            {
                var nextCornerIndex = (cornerIndex + 1) % tile.CornersCount;
                var cornerPosition = tile.GetCorner(cornerIndex);
                var nextCornerPosition = tile.GetCorner(nextCornerIndex);

                Gizmos.DrawLine(cornerPosition, nextCornerPosition);
            }

            Handles.Label(
                tile.WorldPosition,
                $"{tile.AxialPosition}",
                new GUIStyle()
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontSize = 12,
                    normal = new GUIStyleState()
                    {
                        textColor = color
                    }
                }
            );
        }

        public void DrawCursorGizmo(Vector3 worldPosition)
        {
            this.cursorWorldPosition = worldPosition;
        }

#endif
    }
}