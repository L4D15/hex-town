namespace Becerra.Map
{
    using UnityEngine;

    public class MapTile : MonoBehaviour
    {
        [SerializeField] public GameObject highlightVisual;

        public int Index { get; set; }
        public bool IsHighlighted
        {
            get => _isHighlighted;

            set
            {
                _isHighlighted = value;
                highlightVisual.SetActive(value);
            }
        }

        private bool _isHighlighted;

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