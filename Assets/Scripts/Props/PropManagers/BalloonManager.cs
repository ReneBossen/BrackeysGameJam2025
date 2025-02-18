using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Props.PropManagers
{
    public class BalloonManager : MonoBehaviour
    {
        [SerializeField] private GameObject _balloonPrefab;
        [SerializeField] private List<GameObject> _spawnPoints;

        private void Start()
        {
            SpawnBalloons();
        }

        private void SpawnBalloons()
        {
            foreach (GameObject spawnPoint in _spawnPoints)
            {
                Instantiate(_balloonPrefab, spawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
}
