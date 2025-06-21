using TriggeredAbilities;

namespace Cards.DM03
{
    class Emeral : Engine.Creature
    {
        public Emeral() : base("Emeral", 2, 1000, Interfaces.Race.CyberLord, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.EmeralEffect()));
        }
    }
}
