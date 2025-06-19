using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, 2000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
