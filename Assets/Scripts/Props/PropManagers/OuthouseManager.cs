using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Props.PropManagers
{
    public class OuthouseManager : MonoBehaviour
    {
        [SerializeField]
        private List<Outhouse> _houses;

        private void Awake()
        {
            var good = Random.Range(0, _houses.Count);
            _houses[good].EnableGoodPart();
            _houses.RemoveAt(good);
            foreach (var h in _houses) h.EnableBadPart();
        }
    }
}