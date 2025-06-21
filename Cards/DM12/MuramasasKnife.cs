using ContinuousEffects;

namespace Cards.DM12
{
    class MuramasasKnife : Engine.Creature
    {
        public MuramasasKnife() : base("Muramasa's Knife", 3, 2000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }
    }
}
