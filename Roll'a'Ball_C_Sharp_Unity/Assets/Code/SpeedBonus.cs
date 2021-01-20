using UnityEngine;
using static UnityEngine.Debug;


namespace GeekBrains
{
    public sealed class SpeedBonus : InteractiveObjects, IFlay, IRotation
    {

        #region Fields

        private Player _player;
        private string _playerTag = "Player";
        private float _speedRotation;
        private float _lengthFlay;
        private float _speedMax = 6.0f;
        private float _minFlayRange = 1.0f;
        private float _maxFlayRange = 5.0f;
        private float _minRotationRange = 10.0f;
        private float _maxRotationRange = 50.0f;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _player = new Player();
            _lengthFlay = Random.Range(_minFlayRange, _maxFlayRange);
            _speedRotation = Random.Range(_minRotationRange, _maxRotationRange);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_playerTag))
            {
                Log("Woohoo");
                Interaction();
                Destroy(gameObject);
            }
        }

        #endregion


        #region Methods

        public override void Interaction()
        {
            _player.Speed = _speedMax;
        }

        public void RotationObject()
        {
            throw new System.NotImplementedException();
        }

        public void Flay()
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
