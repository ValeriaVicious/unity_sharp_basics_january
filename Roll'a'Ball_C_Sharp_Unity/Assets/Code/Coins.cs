using UnityEngine;
using static UnityEngine.Debug;


namespace GeekBrains
{
    public sealed class Coins : InteractiveObjects, IFlay, IFlicker
    {
        #region Fields

        private Material _material;
        private string _playerTag = "Player";
        private float _lengthFlay;
        private float _minRange = 1.0f;
        private float _maxRange = 5.0f;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(_minRange, _maxRange);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                Log("I'm here");
                Destroy(gameObject);
            }
        }

        #endregion


        #region Methods

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g,
                _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        #endregion
    }
}
