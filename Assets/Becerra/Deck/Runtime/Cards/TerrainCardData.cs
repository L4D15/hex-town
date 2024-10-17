using Becerra.Map;
using UnityEngine;

namespace Becerra.Deck.Cards
{
    [CreateAssetMenu(fileName = "TerrainCard", menuName = "Becerra/Data/Terrain Card")]
    public class TerrainCardData : CardData
    {
        [SerializeField] private MapTileType terrainType;

        public MapTileType TerrainType => this.terrainType;
    }
}