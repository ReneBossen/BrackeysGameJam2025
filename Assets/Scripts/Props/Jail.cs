using Brackeys.Manager;
using UnityEngine;

namespace Brackeys.Props
{
    public class Jail : MonoBehaviour
    {
        [SerializeField]
        private GameObject _door;

        [SerializeField]
        private Transform _jailPos;

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