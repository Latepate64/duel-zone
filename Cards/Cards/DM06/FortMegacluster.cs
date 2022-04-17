using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class FortMegacluster : EvolutionCreature
    {
        public FortMegacluster() : base("Fort Megacluster", 5, 5000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Engine.Civilization.Water, new OneShotEffects.DrawCardsEffect(1)));
        }
    }
}
