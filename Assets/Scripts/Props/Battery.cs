using Brackeys.Player;
using Brackeys.Player.Interaction;
using System.Linq;
using UnityEngine;

namespace Brackeys.Props
{
    public class Battery : MonoBehaviour, IInteractable
    {
        private Collider _triggerColl;

        public bool CanInteract => true;

        public GameObject GameObject => gameObject;

        public bool IsPendingDeletion { get; set; }

        public void Interact(PlayerController pc)
        {
            pc.GetComponent<PlayerInput>().AddAmmo();
            pc.Unregister(this);
            Destroy(gameObject);
        }

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
                other.GetComponent<PlayerController>().Unregister(this);
                Destroy(gameObject);
            }
        }
    }
}