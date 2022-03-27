using Common;

namespace Cards.Cards.DM10
{
    class AncientHornTheWatcher : Creature
    {
        public AncientHornTheWatcher() : base("Ancient Horn, the Watcher", 5, 5000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.AncientHornTheWatcherAbility());
        }
    }
}
