namespace Cards.Cards.DM09
{
    class VineCharger : Charger
    {
        public VineCharger() : base("Vine Charger", 4, Engine.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect());
        }
    }
}
