namespace Becerra.Map
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(fileName = "MapTilesSettings", menuName = "Becerra/Settings/Map Tiles")]
    public class MapTilesSettings : ScriptableObject
    {
        [System.Serializable]
        internal class TileSetup
        {
            public MapTileType Type;

            [AssetList(AutoPopulate = true, Path = "Art/Sprites/Map")]
            [InlineEditor(InlineEditorModes.LargePreview, Expanded = true)]
            public Sprite Sprite;
        }

        [SerializeField] private TileSetup[] tileSetups;

        public Sprite GetSprite(MapTileType tileType)
        {
            var setup = FindSetup(tileType);

            if (setup == null) return null;

            return setup.Sprite;
        }

        private TileSetup FindSetup(MapTileType tileType)
        {
            foreach (var setup in this.tileSetups)
            {
                if (setup.Type == tileType) return setup;
            }

            return null;
        }
    }
}