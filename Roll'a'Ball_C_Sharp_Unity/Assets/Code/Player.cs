using UnityEngine;


namespace GeekBrains
{
    public class Player : Character
    {
        #region Fields

        private Rigidbody _rigidbody;
        private const string _horizontalInput = "Horizontal";
        private const string _verticalInput = "Vertical";
        private float _speed = 3.0f;

        #endregion


        #region ClassLifeCycles

        public Player(float speed)
        {
            _speed = speed;
        }

        public Player()
        {
        }

        public Player(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        #endregion


        #region Methods

        public override void Move()
        {
            float moveHorizontal = Input.GetAxis(_horizontalInput);
            float moveVertical = Input.GetAxis(_verticalInput);

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidbody.AddForce(movement * _speed);
        }

        #endregion
    }
}



