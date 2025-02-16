using UnityEngine;

namespace Brackeys.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/Weapon/ProjectileWeapon", fileName = "ProjectileWeapon")]
    public class ProjectileWeaponInfo : AWeaponInfo
    {
        [Tooltip("Prefab spawned when shooting")] public GameObject Bullet;
        [Tooltip("Base force of the bullet")] public float PropulsionForce = 10f;

        [Tooltip("Amount of collisions accepted before the object is deleted (recommended only for bouncy objects)")] public Range MaxBounceCount = new() { Min = 1, Max = 1 };
    }

    [System.Serializable]
    public class Range
    {
        public int Min;
        public int Max;

        public int GetValue()
        {
            if (Min == Max) return Min;
            return Random.Range(Min, Max + 1);
        }
    }
}