using Common;

namespace Cards.Cards.DM09
{
    class VineCharger : Charger
    {
        public VineCharger() : base("Vine Charger", 4, Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect());
        }
    }
}
