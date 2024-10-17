namespace Becerra.Map
{
    using Becerra.HexGrid;
    using UnityEngine;

    public class MapTile : MonoBehaviour
    {
        public void SetHexTile(HexTile tile)
        {
            this.transform.position = tile.WorldPosition;
        }

        public void Show()
        {
        }

        public void Hide()
        {
        }

        public void RandomizeType()
        {
            int random = Random.Range(0, System.Enum.GetValues(typeof(MapTileType)).Length);
            var type = (MapTileType)random;
        }
    }
}