using Brackeys.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Props
{
    public class HazardTrigger : MonoBehaviour
    {
        [SerializeField] private List<Hazard> _hazards;
        [SerializeField] private string _targetLayer = "Projectile";

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer(_targetLayer))
            {
                return;
            }

            _hazards.ForEach(hazard => hazard.OnActivate());
        }
    }
}
