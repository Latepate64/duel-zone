using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class AnglerCluster : Creature
    {
        public AnglerCluster() : base("Angler Cluster", 3, 3000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Engine.Civilization.Water, 3000));
        }
    }
}
