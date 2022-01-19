using DuelMastersModels;
using DuelMastersModels.Abilities;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class DestroyCreaturesEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        public DestroyCreaturesEffect(CardFilter filter)
        {
            Filter = filter;
        }

        public DestroyCreaturesEffect(DestroyCreaturesEffect effect) : base(effect)
        {
            Filter = effect.Filter;
        }

        public override OneShotEffect Copy()
        {
            return new DestroyCreaturesEffect(this);
        }

        public override void Apply(Duel duel)
        {
            duel.Destroy(duel.BattleZoneCreatures.Where(x => Filter.Applies(x, duel)).ToList());
        }
    }
}
