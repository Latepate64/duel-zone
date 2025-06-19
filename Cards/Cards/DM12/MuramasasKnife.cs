using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM12
{
    class MuramasasKnife : Engine.Creature
    {
        public MuramasasKnife() : base("Muramasa's Knife", 3, 2000, Engine.Race.Xenoparts, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }
    }
}
