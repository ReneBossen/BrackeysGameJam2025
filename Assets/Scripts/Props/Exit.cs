using UnityEngine;

namespace Brackeys
{
    public class Exit : MonoBehaviour
    {
        [SerializeField]
        private int _validationCount;

        public void DecreaseValidation()
        {
            _validationCount--;
            if (_validationCount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}