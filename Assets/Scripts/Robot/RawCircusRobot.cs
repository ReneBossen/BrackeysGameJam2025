using Brackeys.Translation;
using UnityEngine;

namespace Brakeys.Robot
{
    public class RawCiscusRobot : ASpeakableRobot
    {
        [SerializeField]
        private string _mainKeyName;

        [SerializeField]
        private int _keyCount;

        public override string GetTranslationKey()
        {
            return Translate.Instance.Tr($"{_mainKeyName}_{Random.Range(1, _keyCount + 1):00}");
        }
    }
}