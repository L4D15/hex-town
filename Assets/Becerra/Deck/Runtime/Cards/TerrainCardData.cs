namespace Becerra.Deck.Cards
{
    using Becerra.Map;
    using Unity.VisualScripting;
    using UnityEngine;

    [CreateAssetMenu(fileName = "TerrainCard", menuName = "Becerra/Data/Terrain Card")]
    [Inspectable]
    public class TerrainCardData : CardData
    {
        [SerializeField] private MapTileType terrainType;

        public MapTileType TerrainType => this.terrainType;
    }
}