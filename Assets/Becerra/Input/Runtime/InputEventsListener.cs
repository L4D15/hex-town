namespace Becerra.Input
{
    using Lean.Touch;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

    public class InputEventsListener : MonoBehaviour
    {
        public Camera WorldCamera;

        private bool _isDragging;

        public void Start()
        {
            LeanTouch.OnFingerTap += OnTap;
            LeanTouch.OnGesture += OnGesture;
            LeanTouch.OnFingerUp += OnFingerUp;
        }

        public void OnDestroy()
        {
            LeanTouch.OnFingerTap -= OnTap;
            LeanTouch.OnGesture -= OnGesture;
            LeanTouch.OnFingerUp -= OnFingerUp;
        }

        private void OnTap(LeanFinger finger)
        {
            if (finger.IsOverGui) return;

            var screenPosition = finger.ScreenPosition;

            EventBus.Trigger(CustomEvents.OnTapEvent.EventName, screenPosition);
        }

        private void OnFingerUp(LeanFinger finger)
        {
            if (finger.IsOverGui) return;

            if (this._isDragging)
            {
                Vector2 worldDelta = finger.GetWorldDelta(-this.WorldCamera.transform.position.z, this.WorldCamera);

                EventBus.Trigger(CustomEvents.OnDragFinishedEvent.EventName, worldDelta);
            }

            this._isDragging = false;
        }

        private void OnDrag(LeanFinger finger)
        {
            if (finger.IsOverGui) return;

            Vector2 worldDelta = finger.GetWorldDelta(-this.WorldCamera.transform.position.z, this.WorldCamera);

            if (finger.IsActive == false) return;
            if (finger.Up) return;
            if (worldDelta.magnitude <= 0f) return;

            this._isDragging = true;
            EventBus.Trigger(CustomEvents.OnDragEvent.EventName, worldDelta);
        }

        private void OnGesture(List<LeanFinger> fingers)
        {
#if UNITY_EDITOR
            if (fingers.Count == 2)
            {
                OnDrag(fingers[1]);
            }
#else
            if (fingers.Count == 1)
            {
                OnDrag(fingers[0]);
            }
#endif
        }
    }
}