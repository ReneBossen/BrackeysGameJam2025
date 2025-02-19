using Brackeys.Player;
using Brackeys.Player.Interaction;
using Brackeys.Statics;
using System.Linq;
using UnityEngine;

namespace Brackeys.Props
{
    public class Battery : MonoBehaviour, IInteractable
    {
        private Collider _triggerColl;

        public bool CanInteract { set; get; }

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
            if (!collision.collider.CompareTag(StringHelper.PLAYER_TAG) && collision.collider.name != name && !CanInteract) // Avoid battery colliding with players or between each other for detection
            {
                Debug.Log($"[BAT] Battery collided with {collision.collider.name}");
                _triggerColl.enabled = true;
                CanInteract = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(StringHelper.PLAYER_TAG) && CanInteract)
            {
                other.GetComponent<PlayerInput>().AddAmmo();
                other.GetComponent<PlayerController>().Unregister(this);
                Destroy(gameObject);
            }
        }
    }
}