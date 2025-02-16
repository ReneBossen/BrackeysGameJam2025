using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        public void OnShot()
        {
            Debug.Log("ButtonShot");
        }
    }
}