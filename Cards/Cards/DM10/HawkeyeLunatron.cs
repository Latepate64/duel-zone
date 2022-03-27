using Common;

namespace Cards.Cards.DM10
{
    class HawkeyeLunatron : Creature
    {
        public HawkeyeLunatron() : base("Hawkeye Lunatron", 8, 6000, Subtype.CyberMoon, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCardNoRevealEffect()));
        }
    }
}
