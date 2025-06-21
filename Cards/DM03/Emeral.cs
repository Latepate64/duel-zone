using TriggeredAbilities;

namespace Cards.DM03
{
    class Emeral : Engine.Creature
    {
        public Emeral() : base("Emeral", 2, 1000, Engine.Race.CyberLord, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.EmeralEffect()));
        }
    }
}
