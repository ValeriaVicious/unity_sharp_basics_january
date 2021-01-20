using UnityEngine;


namespace GeekBrains
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        private InteractiveObjects[] _interactiveObjects;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObjects>();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if(interactiveObject is IRotation rotation)
                {
                    rotation.RotationObject();
                }
            }
        }

        #endregion
    }
}
