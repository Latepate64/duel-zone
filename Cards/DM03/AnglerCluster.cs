using ContinuousEffects;

namespace Cards.DM03
{
    sealed class AnglerCluster : Engine.Creature
    {
        public AnglerCluster() : base("Angler Cluster", 3, 3000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(3000, Interfaces.Civilization.Water));
        }
    }
}
