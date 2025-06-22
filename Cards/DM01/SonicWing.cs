namespace Cards.DM01
{
    sealed class SonicWing : Engine.Spell
    {
        public SonicWing() : base("Sonic Wing", 3, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
