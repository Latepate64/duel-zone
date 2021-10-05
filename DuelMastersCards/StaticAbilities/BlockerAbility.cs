using DuelMastersModels.Abilities;

namespace DuelMastersCards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility() : base()
        {
        }

        public BlockerAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new BlockerAbility(this);
        }
    }
}
