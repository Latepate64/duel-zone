using Common;

namespace Cards.Cards.DM11
{
    class GazerEyesShadowOfSecrets : SilentSkillCreature
    {
        public GazerEyesShadowOfSecrets() : base("Gazer Eyes, Shadow of Secrets", 4, 3000, Subtype.Ghost, Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
