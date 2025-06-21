using ContinuousEffects;

namespace Cards.DM03
{
    class AnglerCluster : Engine.Creature
    {
        public AnglerCluster() : base("Angler Cluster", 3, 3000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(3000, Engine.Civilization.Water));
        }
    }
}
