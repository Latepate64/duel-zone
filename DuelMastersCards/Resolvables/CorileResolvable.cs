using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class CorileResolvable : Resolvable
    {
        public CorileResolvable()
        {
        }

        public CorileResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new CorileResolvable(this);
        }

        public override void Resolve(Duel duel, Decision decision)
        {
            // Choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
            if (decision == null)
            {
                var choosable = opponent.BattleZone.GetChoosableCreatures(duel);
                if (choosable.Count() > 1)
                {
                    duel.SetAwaitingChoice(new GuidSelection(Controller, choosable, 1, 1));
                }
                else if (choosable.Any())
                {
                    opponent.PutFromBattleZoneOnTopOfDeck(choosable.Single(), duel);
                }
            }
            else
            {
                opponent.PutFromBattleZoneOnTopOfDeck(duel.GetPermanent((decision as GuidDecision).Decision.Single()), duel);
            }
        }
    }
}
