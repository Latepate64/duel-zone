using Common;

namespace Cards.Cards.DM05
{
    class GigalingQ : Creature
    {
        public GigalingQ() : base("Gigaling Q", 5, 2000, Civilization.Darkness)
        {
            AddSubtypes(Subtype.Survivor, Subtype.Chimera);
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.SlayerAbility()));
        }
    }
}
