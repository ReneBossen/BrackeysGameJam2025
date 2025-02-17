using UnityEngine;

public class GunInspection : MonoBehaviour
{
    [SerializeField] private GameObject[] _inspectionParts;

    private int _activePart = 0;

    private void Start()
    {
        InspectNextWeapon();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InspectNextWeapon();
        }

        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void InspectNextWeapon()
    {
        _activePart = (_activePart + 1) % _inspectionParts.Length;

        for (int i = 0; i < _inspectionParts.Length; i++)
        {
            _inspectionParts[i].SetActive(i % _inspectionParts.Length == _activePart);
        }
    }
}