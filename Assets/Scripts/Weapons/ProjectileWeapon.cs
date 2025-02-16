using Brackeys.SO;

namespace Brackeys.Weapons
{
    public class ProjectileWeapon : IWeapon<ProjectileWeaponInfo>
    {
        public ProjectileWeapon(ProjectileWeaponInfo info)
        {
            Info = info;
        }

        public ProjectileWeaponInfo Info { set; get; }

        public void Fire()
        {

        }
    }
}
