using Brackeys.Manager;
using Brackeys.Translation;

namespace Brakeys.Robot
{
    public class BatteryRobot : ASpeakableRobot
    {
        public override string GetTranslationKey()
        {
            var input = ResourceManager.Instance.PlayerInput;

            if (input.CurrentWeapon == null)
            {
                return Translate.Instance.Tr("speak_battery_noWeapon");
            }
            if (input.CurrentWeapon.BaseInfo.RequiresExternalAmmosCount == 0)
            {
                return Translate.Instance.Tr("speak_battery_noGoodWeapon");
            }
            if (!input.CurrentWeapon.NeedAmmo())
            {
                return Translate.Instance.Tr("speak_battery_alreadyFull");
            }
            while (input.CurrentWeapon.NeedAmmo()) input.AddAmmo();
            return Translate.Instance.Tr("speak_battery_ok");
        }
    }
}