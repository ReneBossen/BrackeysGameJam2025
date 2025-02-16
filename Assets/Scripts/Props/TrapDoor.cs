using UnityEngine;

namespace Brackeys.Props
{
    public class TrapDoor : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }
}