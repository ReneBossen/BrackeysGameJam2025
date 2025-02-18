using Brackeys.Player;
using UnityEngine;

namespace Brackeys.Manager
{
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance { private set; get; }

        [SerializeField]
        private PlayerController _playerController;

        [SerializeField]
        private PlayerInput _playerInput;

        private void Awake()
        {
            Instance = this;
        }

        public PlayerController PlayerController => _playerController;
        public PlayerInput PlayerInput => _playerInput;
    }
}