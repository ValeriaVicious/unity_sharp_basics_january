using UnityEngine;
using Random = UnityEngine.Random;


namespace GeekBrains
{
    public abstract class InteractiveObjects : MonoBehaviour, IInteractable
    {
        #region Fields

        public const string PlayerTag = "Player";
        public bool IsInteractable { get; } = true;

        #endregion

        #region UnityMethods

        private void Start()
        {
            Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!IsInteractable || other.CompareTag(PlayerTag))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        #endregion

        protected abstract void Interaction();

        public void Action()
        {
            if(TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

    }
}
