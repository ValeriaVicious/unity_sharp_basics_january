using System;
using UnityEngine;


namespace GeekBrains
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            BaseExample<string> data = new BaseExample<string>("userName_0");
            BaseExample<Guid> dataGuid = new SavedData<int, Guid, object>(Guid.NewGuid());
            SavedData<int, Guid, object> dataGuidTwo = new SavedData<int, Guid, object>(Guid.NewGuid());
        }
    }
}
