using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Props
{
    public class HoopGame : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spotlights;
        [SerializeField] private List<GameObject> _basketBalls;

        private bool _isActive = false;

        private void Start()
        {
            _spotlights.ForEach(spotlight => spotlight.SetActive(_isActive));
            _basketBalls.ForEach(ball => ball.GetComponent<FollowPath>().ToggleMove());
        }

        public void Toggle()
        {
            _isActive = !_isActive;
            _spotlights.ForEach(spotlight => spotlight.SetActive(_isActive));
            _basketBalls.ForEach(ball => ball.GetComponent<FollowPath>().ToggleMove());
        }
    }
}
