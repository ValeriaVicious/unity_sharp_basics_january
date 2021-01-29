﻿using UnityEngine;
using UnityEngine.UI;


namespace GeekBrains
{
    public sealed class DisplayBonuses
    {
        #region Fields

        private Text _text;

        #endregion


        #region ClassLifeCycles

        public DisplayBonuses()
        {

        }

        #endregion


        #region Methods

        public void Display(int value)
        {
            _text.text = $"Собрано: {value}";
        }

        #endregion
    }
}
