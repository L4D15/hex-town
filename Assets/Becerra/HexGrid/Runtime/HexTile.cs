namespace Becerra.HexGrid
{
    using Becerra.HexGrid.Coordinates;
    using UnityEngine;

    /// <summary>
    /// Base implementation of a hex tile inside a hex grid.
    /// </summary>
    public class HexTile : IHexTile
    {
        /// <summary>
        /// Square root of three used to calculate the width of the tile.
        /// </summary>
        private const float WidthFactor = 1.7320508075688772935274463415059f;

        /// <summary>
        /// Used to calculate the height of the tile.
        /// </summary>
        private const float HeightFactor = 2.0f;

        /// <summary>
        /// Collection of all corners of this tile.
        /// </summary>
        private readonly Vector2[] corners;

        /// <summary>
        /// Coordinates of all 6 neighbors to this tile.
        /// </summary>
        private CubeCoordinates[] neighbors;

        /// <summary>
        /// Initializes a new instance of the <see cref="HexTile" /> class
        /// </summary>
        public HexTile()
        {
            this.corners = new Vector2[CornersCount];
            this.neighbors = new CubeCoordinates[NeighborsCount];

            SetSize(1f);
            SetCubePosition(new CubeCoordinates(0, 0, 0));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexTile"/> class with
        /// an initial position inside the grid and a default size of 1.
        /// </summary>
        /// <param name="cubePosition"></param>
        public HexTile(CubeCoordinates cubePosition)
        {
            this.corners = new Vector2[CornersCount];
            this.neighbors = new CubeCoordinates[NeighborsCount];

            SetSize(1f);
            SetCubePosition(cubePosition);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexTile"/> class with
        /// an initial position and size.
        /// </summary>
        /// <param name="cubePosition"></param>
        /// <param name="size"></param>
        public HexTile(CubeCoordinates cubePosition, float size)
        {
            this.corners = new Vector2[CornersCount];
            this.neighbors = new CubeCoordinates[NeighborsCount];

            SetSize(size);
            SetCubePosition(cubePosition);
        }

        /// <summary>
        /// Gets the position in world space (unity coordinates)
        /// </summary>
        public Vector2 WorldPosition { get; private set; }

        /// <summary>
        /// Gets the position inside the hex grid, using cube coordinates.
        /// </summary>
        public CubeCoordinates CubePosition { get; private set; }

        /// <summary>
        /// Gets the position inside the hex grid, using offset coordinates.
        /// </summary>
        public OffsetCoordinates OffsetPosition { get; private set; }

        /// <summary>
        /// Gets the position inside the hex grid, using axial coordinates.
        /// </summary>
        public AxialCoordinates AxialPosition { get; private set; }

        /// <summary>
        /// Gets the size of the tile, from the center to one of the corners.
        /// </summary>
        public float Size { get; private set; }

        /// <summary>
        /// Gets the full width of the tile, from left to right.
        /// </summary>
        public float Width { get; private set; }

        /// <summary>
        /// Gets the full height of the tile, from bottom to top.
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// Number of corners in a hex.
        /// </summary>
        public int CornersCount => 6;

        /// <summary>
        /// Number of neighbors a hex tile can have.
        /// </summary>
        public int NeighborsCount => 6;

        /// <summary>
        /// Gets the world position of one of the 6 corners of the tile.
        /// </summary>
        /// <param name="cornerIndex">Index of the tile, from 0 to <see cref="CornersCount" /></param>
        /// <returns>World position of the corner.</returns>
        public Vector2 GetCorner(int cornerIndex)
        {
            int index = Mathf.Clamp(cornerIndex, 0, this.corners.Length - 1);

            return this.corners[index];
        }

        /// <summary>
        /// Gets the position of a neighbor tile.
        /// </summary>
        /// <param name="neighborIndex">Index of the neighbor, from 0 to <see cref="NeighborsCount"/></param>
        /// <returns>Cube position of the neighbor tile.</returns>
        public CubeCoordinates GetNeighborPosition(int neighborIndex)
        {
            int index = neighborIndex % NeighborsCount;

            return this.neighbors[index];
        }

        /// <summary>
        /// Sets the world position of the tile, using its center as pivot.
        /// </summary>
        /// <param name="worldPosition">Position in world (unity coordinates)</param>
        public void SetWorldPosition(Vector2 worldPosition)
        {
            this.WorldPosition = worldPosition;

            this.OnWorldPositionChanged();
        }

        /// <summary>
        /// Sets the position of the tile inside a hex grid.
        /// </summary>
        /// <param name="cubePosition">Position in cube coordinates.</param>
        public void SetCubePosition(CubeCoordinates cubePosition)
        {
            this.CubePosition = cubePosition;
            this.OffsetPosition = CoordinatesConversor.CubeToOffset(cubePosition);
            this.AxialPosition = CoordinatesConversor.CubeToAxial(cubePosition);

            this.OnGridPositionChanged();
        }

        /// <summary>
        /// Sets the position of the tile inside a hex grid.
        /// </summary>
        /// <param name="offsetPosition">Position in offset coordinates.</param>
        public void SetOffsetPosition(OffsetCoordinates offsetPosition)
        {
            this.OffsetPosition = offsetPosition;
            this.CubePosition = CoordinatesConversor.OffsetToCube(offsetPosition);
            this.AxialPosition = CoordinatesConversor.OffsetToAxial(offsetPosition);

            this.OnGridPositionChanged();
        }

        /// <summary>
        /// Sets the position of the tile inside a hex grid.
        /// </summary>
        /// <param name="axialPosition">Position in axial coordinates.</param>
        public void SetAxialPosition(AxialCoordinates axialPosition)
        {
            this.AxialPosition = axialPosition;
            this.CubePosition = CoordinatesConversor.AxialToCube(axialPosition);
            this.OffsetPosition = CoordinatesConversor.AxialToOffset(axialPosition);

            this.OnGridPositionChanged();
        }

        /// <summary>
        /// Sets the size of the hex tile.
        /// </summary>
        /// <param name="size">Size of the tile from the center to one of its corners.</param>
        public void SetSize(float size)
        {
            this.Size = size;
            this.Width = CalculateWidth(size);
            this.Height = CalculateHeight(size);

            this.OnSizeChanged();
        }

        /// <summary>
        /// Calculates the total width of a tile.
        /// </summary>
        /// <param name="size">Size of the tile from its center to one of its corners.</param>
        /// <returns>Total width of a tile, from left to right.</returns>
        public static float CalculateWidth(float size)
        {
            return size * WidthFactor;
        }

        /// <summary>
        /// Calculates the total height of a tile.
        /// </summary>
        /// <param name="size">Size of the tile, from its center to one of its corners.</param>
        /// <returns>Total height of a tile, from bottom to top.</returns>
        public static float CalculateHeight(float size)
        {
            return size * HeightFactor;
        }

        /// <summary>
        /// Calculates the world position of a corner.
        /// </summary>
        /// <param name="center">World position of the tile center.</param>
        /// <param name="size">Size of the tile, from its center to one of its corners.</param>
        /// <param name="cornerIndex">Index of the corner, from 0 to <see cref="CornersCount"/></param>
        /// <returns>World position (unity coordinates) of the corner.</returns>
        private static Vector2 CalculateCornerWorldPosition(Vector2 center, float size, int cornerIndex)
        {
            var angle_deg = (60f * cornerIndex) - 30f;
            var angle_rad = Mathf.PI / 180f * angle_deg;
            var x = center.x + (size * Mathf.Cos(angle_rad));
            var y = center.y + (size * Mathf.Sin(angle_rad));

            return new Vector2(x, y);
        }

        /// <summary>
        /// When the size of the tile has changed.
        /// </summary>
        private void OnSizeChanged()
        {
            this.RecalculateCorners();
        }

        /// <summary>
        /// When the position in world has changed.
        /// </summary>
        private void OnWorldPositionChanged()
        {
            this.RecalculateCorners();
        }

        /// <summary>
        /// When the position inside the grid has changed.
        /// </summary>
        private void OnGridPositionChanged()
        {
            this.RecalculateNeighbors();

            this.WorldPosition = CoordinatesConversor.CubeToWorld(this.CubePosition, this.Width, this.Height);
            this.OnWorldPositionChanged();
        }

        /// <summary>
        /// Recalculates the position of all six corners.
        /// This must be called when the position or size of the tile changes.
        /// </summary>
        private void RecalculateCorners()
        {
            for (int i = 0; i < this.corners.Length; i++)
            {
                this.corners[i] = CalculateCornerWorldPosition(this.WorldPosition, this.Size, i);
            }
        }

        /// <summary>
        /// Recalculates the coordinates of all neighboring tiles.
        /// This must be called when the position inside the grid is changed.
        /// </summary>
        private void RecalculateNeighbors()
        {
            CoordinatesConversor.CalculateNeighboringTiles(this.CubePosition, ref this.neighbors);
        }
    }
}