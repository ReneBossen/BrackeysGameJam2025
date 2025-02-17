using Brackeys.Player;
using System.Linq;
using UnityEngine;

namespace Brackeys.Props
{
    public class Battery : MonoBehaviour
    {
        private Collider _triggerColl;

        private void Awake()
        {
            _triggerColl = GetComponentsInChildren<Collider>().First(x => x.enabled == false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _triggerColl.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerInput>().AddAmmo();
                Destroy(gameObject);
            }
        }
    }
}