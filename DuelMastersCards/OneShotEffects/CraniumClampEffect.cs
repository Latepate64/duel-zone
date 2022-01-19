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

        public override void Apply(Game game)
        {
            // Your opponent chooses and discards 2 cards from his hand.
            var opponent = game.GetOpponent(game.GetPlayer(Controller));
            if (opponent.Hand.Cards.Count <= Amount)
            {
                game.Discard(opponent.Hand.Cards.ToList());
            }
            else
            {
                var dec = opponent.Choose(new GuidSelection(opponent.Id, opponent.Hand.Cards, Amount, Amount));
                game.Discard(dec.Decision.Select(x => game.GetCard(x)).ToList());
            }
        }
    }
}
