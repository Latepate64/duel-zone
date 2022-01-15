using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class CraniumClampResolvable : Resolvable
    {
        const int Amount = 2;

        public CraniumClampResolvable()
        {
        }

        public CraniumClampResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new CraniumClampResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // Your opponent chooses and discards 2 cards from his hand.
            var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
            if (decision == null)
            {
                if (opponent.Hand.Cards.Count <= Amount)
                {
                    duel.Discard(opponent.Hand.Cards.ToList());
                    return null;
                }
                else
                {
                    return new GuidSelection(opponent.Id, opponent.Hand.Cards, Amount, Amount);
                }
            }
            else
            {
                duel.Discard((decision as GuidDecision).Decision.Select(x => duel.GetCard(x)).ToList());
                return null;
            }
        }
    }
}
