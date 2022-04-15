using Common;

namespace Cards.Cards.DM07
{
    class WorldTreeRootOfLife : EvolutionCreature
    {
        public WorldTreeRootOfLife() : base("World Tree, Root of Life", 6, 7000, Engine.Subtype.TreeFolk, Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
            AddStaticAbilities(new ContinuousEffects.StealthEffect(Civilization.Darkness));
            AddDoubleBreakerAbility();
        }
    }
}
