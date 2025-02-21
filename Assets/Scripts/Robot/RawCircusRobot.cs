using UnityEngine;

namespace Brakeys.Robot
{
    public class RawCiscusRobot : ASpeakableRobot
    {
        [SerializeField]
        private string[] _targetTranslationKey;

        public override string GetTranslationKey()
        {
            return _targetTranslationKey[Random.Range(0, _targetTranslationKey.Length)];
        }
    }
}