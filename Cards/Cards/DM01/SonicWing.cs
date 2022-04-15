namespace Cards.Cards.DM01
{
    class SonicWing : Spell
    {
        public SonicWing() : base("Sonic Wing", 3, Engine.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
