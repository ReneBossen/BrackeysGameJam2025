using Brackeys.Manager;
using Brackeys.Props;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Brackeys
{
    public class Exit : MonoBehaviour
    {
        public static Exit Instance { get; private set; }

        [SerializeField] private GameObject _ventCover;
        [SerializeField] private TextMeshPro _exitText;

        private int _validationCount;
        private readonly List<GameObject> _exitObjects = new();
        private BoxCollider _collider;

        private void Awake()
        {
            Instance = this;
            _collider = GetComponent<BoxCollider>();
            _validationCount = 0;
        }

        public void AddRequiredObject(GameObject requiredObject)
        {
            _exitObjects.Add(requiredObject);
            _validationCount = _exitObjects.Count; // + 1; // Blue buttons are not registered
            UpdateExitText();
        }

        public void DecreaseValidation()
        {
            Debug.Log($"Exit validation triggered with {_validationCount} targets left");
            ResourceManager.Instance.PlayerController.PlayObjectiveNoise();
            _validationCount--;
            UpdateExitText();
            if (_validationCount <= 0)
            {
                _collider.enabled = false;
                Destroy(_ventCover);
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

        private void UpdateExitText()
        {
            int validatedCount = _exitObjects.Count - _validationCount;
            _exitText.text = $"Exit\n{validatedCount} / {_exitObjects.Count}";
        }
    }
}