using Common;

namespace Cards.Cards.DM05
{
    class GalliaZohlIronGuardianQ : Creature
    {
        public GalliaZohlIronGuardianQ() : base("Gallia Zohl, Iron Guardian Q", 5, 2000, Civilization.Light)
        {
            AddSubtypes(Subtype.Survivor, Subtype.Guardian);
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.BlockerAbility()));
        }
    }
}
