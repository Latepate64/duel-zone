using Abilities.Triggered;

namespace Cards.Cards.DM10
{
    class HawkeyeLunatron : Engine.Creature
    {
        public HawkeyeLunatron() : base("Hawkeye Lunatron", 8, 6000, Engine.Race.CyberMoon, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCardNoRevealEffect()));
        }
    }
}
