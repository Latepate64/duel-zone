using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class CraniumClampEffect : OneShotEffect
    {
        const int Amount = 2;

        public CraniumClampEffect()
        {
        }

        public CraniumClampEffect(OneShotEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new CraniumClampEffect(this);
        }

        public override void Apply(Duel duel)
        {
            // Your opponent chooses and discards 2 cards from his hand.
            var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
            if (opponent.Hand.Cards.Count <= Amount)
            {
                duel.Discard(opponent.Hand.Cards.ToList());
            }
            else
            {
                var dec = opponent.Choose(new GuidSelection(opponent.Id, opponent.Hand.Cards, Amount, Amount));
                duel.Discard(dec.Decision.Select(x => duel.GetCard(x)).ToList());
            }
        }
    }
}
