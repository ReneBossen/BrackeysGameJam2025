using Brackeys.SO;

namespace Brackeys.Weapons
{
    public class ProjectileWeapon : AWeapon<ProjectileWeaponInfo>
    {
        public ProjectileWeapon(ProjectileWeaponInfo info)
        {
            Info = info;
        }

        public ProjectileWeaponInfo Info { set; get; }

        public override void Fire()
        {

        }
    }
}
