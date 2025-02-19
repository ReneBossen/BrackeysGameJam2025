using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class ProjectileWeapon : AWeapon<ProjectileWeaponInfo>
    {
        public ProjectileWeapon(ProjectileWeaponInfo info) : base(info)
        { }

        public override void Fire(Vector3 spawnPos, Vector3 forward, Vector3 gunModel, Quaternion rot)
        {
            if (!CanShoot) return;

            base.Fire(spawnPos, forward, gunModel, rot);

            var bullet = GameObject.Instantiate(Info.Bullet, spawnPos, rot);
            bullet.GetComponent<Rigidbody>().linearVelocity = forward * Info.PropulsionForce;
            bullet.GetComponent<Bullet>().Info = Info;
        }
    }
}
