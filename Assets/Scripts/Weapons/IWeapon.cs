using Brackeys.SO;

namespace Brackeys.Weapons
{
    public interface IWeapon
    {
        public AWeaponInfo Info { set; get; }

        public void Fire();
    }
}