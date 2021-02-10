using System;
using UnityEngine;
using UnityEngine.UI;


namespace GeekBrains
{
    public sealed class DisplayEndGame
    {
        #region Fields

        private Text _finishGameLabel;

        #endregion


        #region ClassLifeCycles

        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }

        #endregion


        #region Methods

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"Game Over! {name} {color}";
        }

        #endregion
    }
}