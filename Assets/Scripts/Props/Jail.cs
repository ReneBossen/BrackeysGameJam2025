using Brackeys.Interfaces;
using Brackeys.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Props
{
    public class Jail : MonoBehaviour, IActivateable
    {
        public static Jail Instance { private set; get; }

        public bool CanActivate { private set; get; }

        [SerializeField]
        private GameObject _door;

        [SerializeField]
        private Transform _jailPos;

        [SerializeField] private Animator _enclosureAnimator;

        private Animator _animator;
        private string _toggle = "Toggle";

        private void Awake()
        {
            Instance = this;

            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _enclosureAnimator.Play("Enclosure Idle Closed");
        }

        public void SetToJail()
        {
            GameObject player = ResourceManager.Instance.PlayerController.gameObject;
            player.GetComponent<CharacterController>().enabled = false;

            player.transform.position = _jailPos.position;

            player.GetComponent<CharacterController>().enabled = true;

            _enclosureAnimator.Play("Enclosure Idle Open");
        }

        private void OpenDoor()
        {
            _animator.SetTrigger(_toggle);
            _door.GetComponent<BoxCollider>().enabled = false;
            CanActivate = false;
        }

        private IEnumerator CloseDoor()
        {
            yield return new WaitForSeconds(5f);
            _animator.SetTrigger(_toggle);
            _door.GetComponent<BoxCollider>().enabled = true;
            CanActivate = true;
            _enclosureAnimator.SetTrigger(_toggle);
        }

        public void OnActivate()
        {
            OpenDoor();
        }
    }
}