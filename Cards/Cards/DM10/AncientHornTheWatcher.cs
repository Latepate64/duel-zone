namespace Cards.Cards.DM10
{
    class AncientHornTheWatcher : Creature
    {
        public AncientHornTheWatcher() : base("Ancient Horn, the Watcher", 5, 5000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.AncientHornTheWatcherAbility(new OneShotEffects.UntapAllTheCardsInYourManaZoneEffect()));
        }
    }
}
