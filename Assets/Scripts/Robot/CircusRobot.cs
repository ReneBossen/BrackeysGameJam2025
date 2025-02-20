using UnityEngine;

namespace Brakeys.Robot
{
    public class CiscusRobot : ASpeakableRobot
    {
        [SerializeField]
        private string _targetTranslationKey;
        public override string GetTranslationKey()
        {
            return _targetTranslationKey;
        }
    }
}