using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal abstract class OneShotEffectForCreature : OneShotEffect
    {
        internal IBattleZoneCreature Creature { get; private set; }

        protected OneShotEffectForCreature(IBattleZoneCreature creature)
        {
            Creature = creature;
        }
    }
}
