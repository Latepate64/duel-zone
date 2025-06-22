using TriggeredAbilities;

namespace Cards.DM10
{
    sealed class HawkeyeLunatron : Engine.Creature
    {
        public HawkeyeLunatron() : base("Hawkeye Lunatron", 8, 6000, Interfaces.Race.CyberMoon, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCardNoRevealEffect()));
        }
    }
}
