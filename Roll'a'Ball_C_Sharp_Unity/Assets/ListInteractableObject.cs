using System.Collections;
using System;
using Object = UnityEngine.Object;


namespace GeekBrains
{
    public sealed class ListInteractableObject : IEnumerator, IEnumerable
    {
        #region Fields

        private InteractiveObjects[] _interactiveObjects;
        private InteractiveObjects _current;
        private int _index = -1;

        #endregion


        #region ClassLifeCycles

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObjects>();
            Array.Sort(_interactiveObjects);
        }

        #endregion


        #region Methods

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;


        #endregion
    }
}
