using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class ProjectileWeapon : AWeapon<ProjectileWeaponInfo>
    {
        public ProjectileWeapon(ProjectileWeaponInfo info)
        {
            Info = info;
        }

        public ProjectileWeaponInfo Info { set; get; }

        public override void Fire(Vector3 spawnPos, Vector3 forward)
        {
            var bullet = GameObject.Instantiate(Info.Bullet, spawnPos, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().linearVelocity = forward * Info.PropulsionForce;
            bullet.GetComponent<Bullet>().Info = Info;
        }
    }
}
