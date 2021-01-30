using System;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        private Reference _reference;
        private int _countBonuses;
        private int _numberOfScene = 0;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _reference = new Reference();

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Coin);

            _cameraController = new CameraController(_reference.PlayerBall.transform,
                _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(_reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);

            this._reference.RestartButton.onClick.AddListener(this.RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);

            foreach (var item in _interactiveObject)
            {
                if (item is Mantrap mantrap)
                {
                    mantrap.OnCaughtPlayerChange += CaughtPlayer;
                    mantrap.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (item is Coins coin)
                {
                    coin.OnPointChange += AddBonuse;
                }

                if (item is SpeedBonus speedBonus)
                {
                    speedBonus.OnPointChange += AddBonuse;
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

        public void RestartGame()
        {
            SceneManager.LoadScene(_numberOfScene);
            Time.timeScale = 1.0f;
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

                if (item is Coins coins)
                {
                    coins.OnPointChange -= AddBonuse;
                }

                if (item is SpeedBonus speedBonus)
                {
                    speedBonus.OnPointChange -= AddBonuse;
                }
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }


        #endregion
    }
}
