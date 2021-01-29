using System;
using UnityEngine;
using UnityEngine.UI;


namespace GeekBrains
{
    public sealed class DisplayBonuses
    {
        #region Fields

        private Text _coinLabel;

        #endregion


        #region ClassLifeCycles

        public DisplayBonuses(GameObject coin)
        {
            _coinLabel = coin.GetComponentInChildren<Text>();
            _coinLabel.text = string.Empty;
        }

        #endregion


        #region Methods

        public void Display(int value)
        {
            _coinLabel.text = $"Собрано: {value}";
        }

        #endregion
    }
}
