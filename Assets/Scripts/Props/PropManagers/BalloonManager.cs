using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Brackeys.Props.PropManagers
{
    public class BalloonManager : MonoBehaviour
    {
        [SerializeField] private GameObject _balloonPrefab;
        [SerializeField] private List<GameObject> _spawnPoints;
        [SerializeField] private Material _ropeMaterial;

        [Header("Configuration")]
        [SerializeField, Range(0f, 4f)] private float _maxBaloonRopeLength;

        private const float _minDistance = 0f;

        private readonly List<GameObject> _balloons = new();

        private void Start()
        {
            SpawnBalloons();
        }

        private void SpawnBalloons()
        {
            foreach (GameObject spawnPoint in _spawnPoints)
            {
                GameObject balloonObject = Instantiate(_balloonPrefab, spawnPoint.transform.position, Quaternion.identity);
                _balloons.Add(balloonObject);

                InitializeBalloon(balloonObject, spawnPoint);
            }
        }

        private void Update()
        {
            if (!_balloons.Any())
                return;

            _balloons.ForEach(balloon =>
            {
                balloon.GetComponent<Balloon>().ApplyGravity();
                balloon.GetComponent<LineRenderer>().SetPosition(1, balloon.transform.position);
            });
        }

        private void InitializeBalloon(GameObject balloonObject, GameObject spawnPoint)
        {
            Balloon balloon = balloonObject.GetComponent<Balloon>();
            float randomMaxDistance = Random.Range(_minDistance, _maxBaloonRopeLength);
            Rigidbody connectedBody = spawnPoint.GetComponent<Rigidbody>();
            balloon.Initialize(connectedBody, _minDistance, randomMaxDistance);

            AddRope(balloonObject, spawnPoint);
        }

        private void AddRope(GameObject balloonObject, GameObject spawnPoint)
        {
            LineRenderer rope = balloonObject.AddComponent<LineRenderer>();
            rope.SetPosition(0, spawnPoint.transform.position);
            rope.material = _ropeMaterial;
            rope.startWidth = 0.04f;
            rope.endWidth = 0.04f;
            rope.enabled = true;
        }
    }
}