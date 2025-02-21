using UnityEngine;

namespace Brackeys.Props
{
    public class ColorLight : MonoBehaviour
    {
        private Light _light;

        private void Awake()
        {
            _light = GetComponent<Light>();
        }

        public void SetValidationColor()
        {
            _light.color = Color.green;
        }
    }
}