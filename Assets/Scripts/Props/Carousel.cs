using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Props
{
    public class Carousel : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        void Update()
        {
            transform.Rotate(new Vector3(0, 0, -_rotationSpeed) * Time.deltaTime);
        }
    }
}