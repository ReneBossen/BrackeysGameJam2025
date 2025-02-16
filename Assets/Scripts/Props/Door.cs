using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Door : MonoBehaviour, IActivateable
    {
        public void OnActivate()
        {
            Debug.Log("[DOOR] Winning Door Activated");
        }
    }
}