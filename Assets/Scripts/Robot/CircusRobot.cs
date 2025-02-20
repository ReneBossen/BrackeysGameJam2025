using Brackeys.Player;
using Brackeys.Player.Interaction;
using Brackeys.Translation;
using Brackeys.VN;
using UnityEngine;

namespace Brakeys.Robot
{
    public class CiscusRobot : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TextDisplay _display;

        [SerializeField]
        private string _targetTranslationKey;

        private Animator _anim;

        public bool CanInteract => true;

        public GameObject GameObject => gameObject;

        public void Interact(PlayerController pc)
        {
            _display.ToDisplay = Translate.Instance.Tr(_targetTranslationKey);
            _anim.SetBool("IsSpeaking", true);
        }

        private void Awake()
        {
            _display.ToDisplay = null;

            _anim = GetComponent<Animator>();
            _display.OnDone.AddListener(() =>
            {
                _anim.SetBool("IsSpeaking", false);
            });
        }
    }
}