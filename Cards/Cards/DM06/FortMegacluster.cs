using Common;

namespace Cards.Cards.DM06
{
    class FortMegacluster : EvolutionCreature
    {
        public FortMegacluster() : base("Fort Megacluster", 5, 5000, Subtype.CyberCluster, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.TapAbilityAddingAbility(Civilization.Water, new OneShotEffects.DrawEffect(1)));
        }
    }
}
