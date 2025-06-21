using ContinuousEffects;

namespace Cards.DM06
{
    class FortMegacluster : EvolutionCreature
    {
        public FortMegacluster() : base("Fort Megacluster", 5, 5000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Interfaces.Civilization.Water, new OneShotEffects.DrawCardEffect()));
        }
    }
}
