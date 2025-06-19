using Cards.TriggeredAbilities;

namespace Cards.Cards.DM03
{
    class Emeral : Creature
    {
        public Emeral() : base("Emeral", 2, 1000, Engine.Race.CyberLord, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.EmeralEffect()));
        }
    }
}
