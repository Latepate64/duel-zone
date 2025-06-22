namespace Cards.DM11
{
    sealed class SolarTrap : Engine.Spell
    {
        public SolarTrap() : base("Solar Trap", 1, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
