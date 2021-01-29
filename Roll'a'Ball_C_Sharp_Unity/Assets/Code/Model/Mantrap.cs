using UnityEngine;
using static UnityEngine.Debug;


namespace GeekBrains
{
    public sealed class Mantrap : InteractiveObjects, IFlay, IFlicker, IExecute
    {
        #region Fields

        private Material _material;
        private float _lengthFlay;
        private float _minFlayRange = 1.0f;
        private float _maxFlayRange = 5.0f;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(_minFlayRange, _maxFlayRange);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                Log("I kill you!");
                Destroy(other.gameObject);
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

        protected override void Interaction()
        {
            
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
