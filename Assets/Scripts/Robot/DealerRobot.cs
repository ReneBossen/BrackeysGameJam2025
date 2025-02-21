using Brackeys.Manager;
using Brackeys.Translation;

namespace Brakeys.Robot
{
    public class Dealer : ASpeakableRobot
    {
        public override string GetTranslationKey()
        {
            var input = ResourceManager.Instance.PlayerInput;

            if (input.CurrentWeapon == null)
            {
                return Translate.Instance.Tr("speak_jailed_noWeapon");
            }
            if (input.CurrentWeapon.BaseInfo.RequiresExternalAmmosCount == 0)
            {
                return Translate.Instance.Tr("speak_jailed_noGoodWeapon");
            }
            if (!input.CurrentWeapon.NeedAmmo())
            {
                return Translate.Instance.Tr("speak_jailed_alreadyFull");
            }
            while (input.CurrentWeapon.NeedAmmo())
                input.AddAmmo();
            return Translate.Instance.Tr("speak_jailed_ok");
        }
    }
}