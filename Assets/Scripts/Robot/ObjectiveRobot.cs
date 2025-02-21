using Brackeys.Manager;
using Brackeys.Props;
using Brackeys.Translation;
using UnityEngine;

namespace Brakeys.Robot
{
    public class ObjectiveRobot : ASpeakableRobot
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private string _keyOff, _keyOn;

        public override string GetTranslationKey()
        {
            return Translate.Instance.Tr(_button.IsActivated ? _keyOn : _keyOff);
        }
    }
}