using Becerra.Map;
using UnityEngine;

namespace Becerra.Input.UseCases
{
    [RequireComponent(typeof(MapView))]
    public class MapInputHandler : MonoBehaviour
    {
        public Camera raycastCamera;

        private Vector2 CursorPosition
        {
            get
            {
#if UNITY_EDITOR
                return UnityEngine.Input.mousePosition;
#elif UNITY_IOS || UNITY_ANDROID
                if (UnityEngine.Input.touchCount > 1)
                {
                    return UnityEngine.Input.GetTouch(0).position;
                }
#endif
            }
        }

        private MapView _mapView;
        private Plane _plane;
        private Vector3 _worldPoint;
        private bool _isHit;
        private MapTile _highlightedTile;

        private void Awake()
        {
            _plane = new Plane(transform.up, transform.position);
            _mapView = GetComponent<MapView>();
        }

        private void Update()
        {
            if (raycastCamera == null) return;

            var cursorPosition = CursorPosition;
            var ray = raycastCamera.ScreenPointToRay(cursorPosition);

            if (_plane.Raycast(ray, out var distance))
            {
                _worldPoint = ray.GetPoint(distance);
                _isHit = true;
            }
            else
            {
                _isHit = false;
            }

            if (_isHit)
            {
                var coordinates = _mapView.Grid.WorldToGridPosition(_worldPoint);
                _mapView.Grid.HighlightTile(coordinates);
            }
        }

        private void OnDrawGizmos()
        {
            if (_mapView != null && _isHit)
            {
                _mapView.Grid.DrawCursorGizmo(_worldPoint);
            }
        }
    }
}