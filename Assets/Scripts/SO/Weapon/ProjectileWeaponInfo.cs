using UnityEngine;

namespace Brackeys.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/Weapon/ProjectileWeapon", fileName = "ProjectileWeapon")]
    public class ProjectileWeaponInfo : AWeaponInfo
    {
        public GameObject Bullet;
        public float PropulsionForce;
    }
}