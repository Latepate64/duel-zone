namespace Cards.DM11
{
    class GazerEyesShadowOfSecrets : SilentSkillCreature
    {
        public GazerEyesShadowOfSecrets() : base("Gazer Eyes, Shadow of Secrets", 4, 3000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
