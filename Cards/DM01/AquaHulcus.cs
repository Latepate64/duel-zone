using TriggeredAbilities;

namespace Cards.DM01
{
    class AquaHulcus : Engine.Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
