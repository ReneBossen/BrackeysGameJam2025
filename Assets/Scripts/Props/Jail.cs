using Brackeys.Manager;
using UnityEngine;

namespace Brackeys.Props
{
    public class Jail : MonoBehaviour
    {
        public static Jail Instance { private set; get; }

        [SerializeField]
        private GameObject _door;

        [SerializeField]
        private Transform _jailPos;

        private void Awake()
        {
            Instance = this;
        }

        public void SetToJail()
        {
            GameObject player = ResourceManager.Instance.PlayerController.gameObject;
            player.GetComponent<CharacterController>().enabled = false;

            player.transform.position = _jailPos.position;

            player.GetComponent<CharacterController>().enabled = true;
            _door.SetActive(false); //Should be true
        }

        public void OpenDoor()
        {
            _door.SetActive(false);
        }
    }
}