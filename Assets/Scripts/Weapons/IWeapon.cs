using Brackeys.SO;

namespace Brackeys.Weapons
{
    public interface IWeapon<T>
        where T : AWeaponInfo
    {
        public T Info { set; get; }

        public void Fire();
    }
}