using Becerra.Map;
using UnityEngine;

namespace Becerra.Game.UseCases
{
    public class GameFlow : MonoBehaviour
    {
        public MapView Map;

        public void Start()
        {
            Map.GenerateMap();
        }
    }
}