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
            ResourceManager.Instance.PlayerController.transform.position = _jailPos.position;
            _door.SetActive(false);
        }

        public void OpenDoor()
        {
            _door.SetActive(false);
        }
    }
}