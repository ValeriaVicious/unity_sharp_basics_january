﻿using UnityEngine;


namespace GeekBrains
{
    public abstract class PlayerBase : Character
    {
        #region Properties

        public float Speed { get; set; } = 3.0f;

        #endregion


        #region Fields

        public const string HorizontalInput = "Horizontal";
        public const string VerticalInput = "Vertical";

        #endregion


        #region ClassLifeCycles

        public PlayerBase(float speed)
        {
            Speed = speed;
        }

        public PlayerBase()
        {
        }

        #endregion


        #region Methods

        public abstract void Move(float x, float y, float z);

        #endregion
    }
}



