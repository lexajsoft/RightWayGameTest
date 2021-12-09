using System;
using UnityEngine;

namespace Gameplay.Helpers
{
    // Данный класс был переделал под моно только потому что зону хорошо бы было регулировать
    // статичный класс это хорошо, но хорошо когда можно регулировать
    public class GameAreaHelper: MonoBehaviour
    {
        public static GameAreaHelper Instance { get; private set; }

        private static Camera _camera;

        public void Start()
        {
            Instance = this;
            _camera = Camera.main;
        }

        [SerializeField] private float _multySize = 1f;
        
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            float multiSize = Instance? Instance._multySize : 1f;
            
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight * multiSize;
            var bottomBound = camPos.y - camHalfHeight * multiSize;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);

        }
        
        public static bool IsInGameplayArea(Vector3 position, Vector2 size)
        {
            float multiSize = Instance? Instance._multySize : 1f;
            
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight * multiSize;
            var bottomBound = camPos.y - camHalfHeight * multiSize;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = position;

            return (objectPos.x - size.x/2f < rightBound)
                   && (objectPos.x + size.x/2f > leftBound)
                   && (objectPos.y - size.y/2f < topBound)
                   && (objectPos.y + size.y/2f > bottomBound);

        }
    }
}
