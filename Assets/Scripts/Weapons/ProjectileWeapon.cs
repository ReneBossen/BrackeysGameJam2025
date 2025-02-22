using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class ProjectileWeapon : AWeapon<ProjectileWeaponInfo>
    {
        public ProjectileWeapon(ProjectileWeaponInfo info) : base(info)
        { }

        public override bool Fire(Vector3 spawnPos, Transform forwardT, Vector3 gunModel, Quaternion rot)
        {
            if (!CanShoot) return false;

            base.Fire(spawnPos, forwardT, gunModel, rot);

            if (BaseInfo.MultShootIncr == 0)
            {
                var bullet = GameObject.Instantiate(Info.Bullet, spawnPos, rot);
                bullet.GetComponent<Rigidbody>().linearVelocity = forwardT.forward * Info.PropulsionForce;
                bullet.GetComponent<Bullet>().Info = Info;
            }
            else
            {
                for (int i = 0; i < BaseInfo.MultShootIncr; i++)
                {
                    {
                        var bL = GameObject.Instantiate(Info.Bullet, spawnPos, rot);
                        bL.transform.Rotate(0f, BaseInfo.AdditiveAngle * (i + 1), 0f, Space.Self);
                        bL.GetComponent<Rigidbody>().linearVelocity = bL.transform.forward * Info.PropulsionForce;
                        bL.GetComponent<Bullet>().Info = Info;
                    }
                    {
                        var bR = GameObject.Instantiate(Info.Bullet, spawnPos, rot);
                        bR.transform.Rotate(0f, -BaseInfo.AdditiveAngle * (i + 1), 0f, Space.Self);
                        bR.GetComponent<Rigidbody>().linearVelocity = bR.transform.forward * Info.PropulsionForce;
                        bR.GetComponent<Bullet>().Info = Info;
                    }
                }
            }

            return true;
        }
    }
}
