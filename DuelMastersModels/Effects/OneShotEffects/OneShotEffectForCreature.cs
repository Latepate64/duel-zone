using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public abstract class OneShotEffectForCreature : OneShotEffect
    {
        public Creature Creature { get; private set; }

        protected OneShotEffectForCreature(Creature creature)
        {
            Creature = creature;
        }
    }
}
