using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM10
{
    sealed class AncientHornTheWatcher : Engine.Creature
    {
        public AncientHornTheWatcher() : base("Ancient Horn, the Watcher", 5, 5000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new AncientHornTheWatcherAbility(new UntapAllTheCardsInYourManaZoneEffect()));
        }
    }
}
