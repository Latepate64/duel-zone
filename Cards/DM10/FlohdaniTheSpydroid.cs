namespace Cards.DM10
{
    sealed class FlohdaniTheSpydroid : SilentSkillCreature
    {
        public FlohdaniTheSpydroid() : base("Flohdani, the Spydroid", 4, 4000, Interfaces.Race.Soltrooper, Interfaces.Civilization.Light)
        {
            AddSilentSkillAbility(new OneShotEffects.ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect());
        }
    }
}
