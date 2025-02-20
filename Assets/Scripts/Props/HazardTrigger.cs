using UnityEngine;

namespace Brackeys.Props
{
    public class HazardTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hazards;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("TriggerHazard"))
            {

            }
        }
    }
}
