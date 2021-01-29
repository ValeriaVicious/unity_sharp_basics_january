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
        private int _countBonuses;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _displayEndGame = new DisplayEndGame();
            _displayBonuses = new DisplayBonuses();

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
