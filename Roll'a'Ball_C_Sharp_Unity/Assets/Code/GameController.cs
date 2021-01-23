using System;
using UnityEngine;
using UnityEngine.UI;


namespace GeekBrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        [SerializeField] private Text _finishGameLabel;
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

                if (interactiveObject is IRotation rotation)
                {
                    rotation.RotationObject();
                }
            }
        }

        #endregion


        #region Methods

        public void Dispose()
        {
            foreach (var item in _interactiveObjects)
            {
                Destroy(item.gameObject);
            }
        }

        #endregion
    }
}
