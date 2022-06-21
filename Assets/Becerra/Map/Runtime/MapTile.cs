namespace Becerra.Map
{
    using Becerra.HexGrid;
    using Unity.VisualScripting;
    using UnityEngine;

    public class MapTile : MonoBehaviour
    {
        public void SetHexTile(HexTile tile)
        {
            Variables.Object(gameObject).Set("Tile", tile);
            this.transform.position = tile.WorldPosition;
        }

        public void Show()
        {
            Variables.Object(gameObject).Set("IsVisible", true);
            CustomEvent.Trigger(gameObject, "Show");
        }

        public void Hide()
        {
            Variables.Object(gameObject).Set("IsVisible", false);
            CustomEvent.Trigger(gameObject, "Hide");
        }

        public void RandomizeType()
        {
            int random = Random.Range(0, System.Enum.GetValues(typeof(MapTileType)).Length);
            var type = (MapTileType)random;

            Variables.Object(gameObject).Set("TileType", type);
        }
    }
}