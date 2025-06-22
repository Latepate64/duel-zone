namespace Cards.DM09
{
    sealed class VineCharger : Charger
    {
        public VineCharger() : base("Vine Charger", 4, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect());
        }
    }
}
