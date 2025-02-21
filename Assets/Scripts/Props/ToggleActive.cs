using UnityEngine;

namespace Brackeys.Props
{
    public class ToggleActive : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }
}