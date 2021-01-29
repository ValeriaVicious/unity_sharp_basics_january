using UnityEngine;


namespace GeekBrains
{
    public abstract class PlayerBase : Character
    {
        #region Properties

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        #endregion


        #region Fields

        public const string HorizontalInput = "Horizontal";
        public const string VerticalInput = "Vertical";
        private float _speed = 3.0f;

        #endregion


        #region ClassLifeCycles

        public PlayerBase(float speed)
        {
            _speed = speed;
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



