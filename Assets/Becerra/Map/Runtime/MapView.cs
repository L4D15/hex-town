namespace Becerra.Map
{
    using Sirenix.OdinInspector;
    using System.Collections.Generic;
    using UnityEngine;
    using uPools;

    public class MapView : MonoBehaviour
    {
        [SceneObjectsOnly]
        public AstarPath Pathfinder;
        [AssetsOnly]
        public MapTile TilePrefab;

        private Dictionary<int, MapTile> tiles;
        private GameObjectPool tilesPool;

        public void GenerateMap()
        {
            this.tilesPool = new GameObjectPool(this.TilePrefab.gameObject);
            var grid = Pathfinder.graphs[0];
            this.tiles = new Dictionary<int, MapTile>();

            grid.active.data.GetNodes(node =>
            {
                var mapTile = CreateTile();

                mapTile.Index = node.NodeIndex;
                mapTile.transform.position = (Vector3)node.position;
                mapTile.Show();
                this.tiles.Add(mapTile.Index, mapTile);
            });
        }

        public MapTile GetTile(int index)
        {
            if (tiles.TryGetValue(index, out MapTile mapTile) == false) return null;

            return mapTile;
        }

        private MapTile CreateTile()
        {
            var tile = tilesPool.Rent(transform).GetComponent<MapTile>();

            tile.RandomizeType();

            return tile;
        }
    }
}