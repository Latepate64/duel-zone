using Common;

namespace Cards.Cards.DM10
{
    class AncientHornTheWatcher : Creature
    {
        public AncientHornTheWatcher() : base("Ancient Horn, the Watcher", 5, Civilization.Nature, 5000, Subtype.HornedBeast)
        {
            // When you put this creature into the battle zone, if you have 5 or more shields, untap all the cards in your mana zone.
            Abilities.Add(new TriggeredAbilities.AncientHornTheWatcherAbility());
        }
    }
}
