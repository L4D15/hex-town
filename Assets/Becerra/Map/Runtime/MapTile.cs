namespace Becerra.Map
{
    using Becerra.HexGrid;
    using UnityEngine;

    public class MapTile : MonoBehaviour
    {
        [SerializeField] public GameObject highlightVisual;

        public HexTile HexTile { get; private set; }

        public void SetHexTile(HexTile tile)
        {
            this.HexTile = tile;
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