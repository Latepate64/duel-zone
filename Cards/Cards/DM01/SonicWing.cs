namespace Cards.Cards.DM01
{
    class SonicWing : Spell
    {
        public SonicWing() : base("Sonic Wing", 3, Common.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
