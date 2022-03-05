namespace Cards.Cards.DM01
{
    class RothusTheTraveler : Creature
    {
        public RothusTheTraveler() : base("Rothus, the Traveler", 4, Common.Civilization.Fire, 4000, Common.Subtype.Armorloid)
        {
            // When you put this creature into the battle zone, destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.RothusTheTravelerEffect()));
        }
    }
}
