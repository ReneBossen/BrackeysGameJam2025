using Brackeys.SO;

namespace Brackeys.Weapons
{
    public abstract class AWeapon<T> : IWeapon
        where T : AWeaponInfo
    {
        public T Info { set; get; }

        public abstract void Fire();
    }
}