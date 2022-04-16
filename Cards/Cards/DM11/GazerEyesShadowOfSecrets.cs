namespace Cards.Cards.DM11
{
    class GazerEyesShadowOfSecrets : SilentSkillCreature
    {
        public GazerEyesShadowOfSecrets() : base("Gazer Eyes, Shadow of Secrets", 4, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
