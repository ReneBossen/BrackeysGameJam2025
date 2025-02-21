using Brackeys.Player;
using Brackeys.Player.Interaction;
using TMPro;
using UnityEngine;

namespace Brackeys.Translation
{
    public class LanguageMachine : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TMP_Text _previewText;

        public bool CanInteract => true;

        public GameObject GameObject => gameObject;

        private int _langIndex;

        private void Awake()
        {
            _previewText.text = Translate.Instance.Tr("lang");
        }

        public void Interact(PlayerController pc)
        {
            var languages = Translate.Languages;
            _langIndex++;
            if (_langIndex == languages.Length)
            {
                _langIndex = 0;
            }
            Translate.Instance.CurrentLanguage = languages[_langIndex];
            _previewText.text = Translate.Instance.Tr("lang");
        }
    }
}