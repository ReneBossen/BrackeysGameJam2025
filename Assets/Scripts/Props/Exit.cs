using Brackeys.Props;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Brackeys
{
    public class Exit : MonoBehaviour
    {
        public static Exit Instance { get; private set; }

        private int _validationCount;
        private readonly List<GameObject> _exitObjects = new();

        private void Awake()
        {
            Instance = this;
            _validationCount = 0;
        }

        public void AddRequiredObject(GameObject requiredObject)
        {
            _exitObjects.Add(requiredObject);
            _validationCount = _exitObjects.Count;
        }

        public void DecreaseValidation()
        {
            _validationCount--;
            if (_validationCount <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            for (int i = 0; i < _exitObjects.Count; i++)
            {
                Gizmos.DrawLine(_exitObjects[i].gameObject.transform.position, transform.position);
            }
        }
    }
}