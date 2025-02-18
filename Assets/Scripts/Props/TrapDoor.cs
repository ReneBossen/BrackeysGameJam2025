using UnityEngine;

namespace Brackeys.Props
{
    public class TrapDoor : MonoBehaviour
    {
        [SerializeField] private bool _startsOpen;

        private void Start()
        {
            //gameObject.SetActive(_startsInScene);
        }

        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }
}