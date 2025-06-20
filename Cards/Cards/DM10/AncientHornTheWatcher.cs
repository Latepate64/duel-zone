using Abilities.Triggered;
using OneShotEffects;

namespace Cards.Cards.DM10
{
    class AncientHornTheWatcher : Engine.Creature
    {
        public AncientHornTheWatcher() : base("Ancient Horn, the Watcher", 5, 5000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new AncientHornTheWatcherAbility(new UntapAllTheCardsInYourManaZoneEffect()));
        }
    }
}
