using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class FortMegacluster : EvolutionCreature
    {
        public FortMegacluster() : base("Fort Megacluster", 5, 5000, Subtype.CyberCluster, Civilization.Water)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Civilization.Water, new OneShotEffects.DrawCardsEffect(1)));
        }
    }
}
