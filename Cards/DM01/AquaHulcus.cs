using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, 2000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
