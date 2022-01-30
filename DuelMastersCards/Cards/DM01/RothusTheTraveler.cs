using Engine;

namespace Cards.Cards.DM01
{
    class RothusTheTraveler : Creature
    {
        public RothusTheTraveler() : base("Rothus, the Traveler", 4, Civilization.Fire, 4000, Subtype.Armorloid)
        {
            // When you put this creature into the battle zone, destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.
            Abilities.Add(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.RothusTheTravelerEffect()));
        }
    }
}
