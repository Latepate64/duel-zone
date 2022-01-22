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

        public DestroyCreaturesEffect(DestroyCreaturesEffect effect)
        {
            Filter = effect.Filter;
        }

        public override OneShotEffect Copy()
        {
            return new DestroyCreaturesEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.Destroy(game.BattleZone.Creatures.Where(x => Filter.Applies(x, game, game.GetPlayer(source.Owner))).ToList());
        }
    }
}
