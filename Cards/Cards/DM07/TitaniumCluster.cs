using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM07
{
    class TitaniumCluster : Engine.Creature
    {
        public TitaniumCluster() : base("Titanium Cluster", 4, 4000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
