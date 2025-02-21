using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Props
{
    public class ShootingGallery : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spotlights;
        [SerializeField] private List<GameObject> _targets;

        public bool IsActive { private set; get; } = false;

        private void Start()
        {
            _spotlights.ForEach(spotlight => spotlight.SetActive(IsActive));
            _targets.ForEach(target => target.gameObject.SetActive(IsActive));
        }
        public void Toggle()
        {
            IsActive = !IsActive;
            _spotlights.ForEach(spotlight => spotlight.SetActive(IsActive));
            _targets.ForEach(target => target.gameObject.SetActive(IsActive));
        }
    }
}
