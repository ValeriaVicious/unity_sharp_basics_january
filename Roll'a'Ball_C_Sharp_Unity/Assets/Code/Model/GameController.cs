using UnityEngine;


namespace GeekBrains
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        private ListExecuteObject _interactiveObject;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        #endregion
    }
}
