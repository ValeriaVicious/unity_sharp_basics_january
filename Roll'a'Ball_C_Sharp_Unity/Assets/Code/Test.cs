using System;
using System.Linq;
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

            var interactableObject = new ListInteractableObject();

            foreach (var item in interactableObject)
            {
                print(item);
            }

            var speedBonusComparer = new SpeedBonusComparer();
            var speedBonusObjects = FindObjectsOfType<SpeedBonus>().ToList();
            speedBonusObjects.Sort(speedBonusComparer);

            foreach (var item in speedBonusObjects)
            {
                print($"{item.name} - {item.Point}");
            }
        }
    }
}
