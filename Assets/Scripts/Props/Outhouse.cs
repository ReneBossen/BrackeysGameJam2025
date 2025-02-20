using UnityEngine;

namespace Brackeys.Props
{
    public class Outhouse : MonoBehaviour
    {
        [SerializeField]
        private GameObject _badPart, _goodPart;

        public void EnableBadPart()
        {
            _badPart.SetActive(true);
            _goodPart.SetActive(false);
        }

        public void EnableGoodPart()
        {
            _badPart.SetActive(false);
            _goodPart.SetActive(true);
        }
    }
}