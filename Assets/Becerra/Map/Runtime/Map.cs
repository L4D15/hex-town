namespace Becerra.Map
{
    using Becerra.HexGrid;
    using Becerra.HexGrid.Coordinates;
    using Sirenix.OdinInspector;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

    public class Map : MonoBehaviour
    {
        [TabGroup("References")]
        public HexGrid Grid;

        [AssetsOnly]
        public MapTile TilePrefab;

        private Dictionary<CubeCoordinates, MapTile> tiles;

        public void GenerateMap(int size)
        {
            var hexTiles = this.Grid.FindTilesInRange(new CubeCoordinates(0, 0, 0), size - 1);

            this.tiles = new Dictionary<CubeCoordinates, MapTile>(hexTiles.Count);

            foreach (HexTile hexTile in hexTiles)
            {
                var mapTile = CreateTile(hexTile);

                this.tiles.Add(hexTile.CubePosition, mapTile);

                mapTile.Show();
            }
        }

        public MapTile GetTile(CubeCoordinates cubeCoordinates)
        {
            if (this.tiles.ContainsKey(cubeCoordinates) == false) return null;

            return this.tiles[cubeCoordinates];
        }

        private MapTile CreateTile(HexTile hexTile)
        {
            var tile = Instantiate<MapTile>(this.TilePrefab, transform);

            tile.SetHexTile(hexTile);
            tile.RandomizeType();

            tile.name = $"TileMap {hexTile.AxialPosition}";

            return tile;
        }
    }
}