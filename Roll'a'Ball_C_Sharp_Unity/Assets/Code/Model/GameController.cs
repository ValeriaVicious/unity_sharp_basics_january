using System;
using UnityEngine;


namespace GeekBrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private int _countBonuses;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();

            var reference = new Reference();
            _cameraController = new CameraController(reference.PlayerBall.transform,
                reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);

            _displayEndGame = new DisplayEndGame(reference.EndGame);
            _displayBonuses = new DisplayBonuses(reference.Coin);

            foreach (var item in _interactiveObject)
            {
                if(item is Mantrap mantrap)
                {
                    mantrap.OnCaughtPlayerChange += CaughtPlayer;
                    mantrap.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if(item is Coins coin)
                {
                    coin.OnPointChange += AddBonuse;
                }

            }
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        #endregion


        #region Methods

        private void CaughtPlayer(string value, Color args)
        {
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        public void Dispose()
        {
            foreach (var item in _interactiveObject)
            {
                if (item is Mantrap mantrap)
                {
                    mantrap.OnCaughtPlayerChange -= CaughtPlayer;
                    mantrap.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if(item is Coins coins)
                {
                    coins.OnPointChange -= AddBonuse;
                }
            }
        }

        #endregion
    }
}
