using Common;

namespace Cards.Cards.DM02
{
    class UltracideWorm : EvolutionCreature
    {
        public UltracideWorm() : base("Ultracide Worm", 6, 11000, Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
