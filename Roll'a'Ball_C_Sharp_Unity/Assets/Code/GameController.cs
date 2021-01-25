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
        private ListInteractableObject _interactableObject;
        private DisplayEndGame _displayEnd;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObjects>();
            _interactableObject = new ListInteractableObject();
            _displayEnd = new DisplayEndGame(_finishGameLabel);

            foreach (var item in _interactableObject)
            {
                if (item is Mantrap mantrap)
                {
                    mantrap.CaughtPlayer += CaughtPlayer;
                    mantrap.CaughtPlayer += _displayEnd.GameOver;
                }
            }
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
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
                if (item is InteractiveObjects interactiveObject)
                {
                    if (item is Mantrap mantrap)
                    {
                        mantrap.CaughtPlayer -= CaughtPlayer;
                        mantrap.CaughtPlayer -= _displayEnd.GameOver;
                    }
                    Destroy(interactiveObject.gameObject);
                }
            }
        }

        #endregion
    }
}
