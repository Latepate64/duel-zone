using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // Choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
            if (decision == null)
            {
                if (opponent.BattleZone.Permanents.Count > 1)
                {
                    return new GuidSelection(Controller, opponent.BattleZone.Permanents, 1, 1);
                }
                else if (opponent.BattleZone.Permanents.Any())
                {
                    opponent.PutFromBattleZoneOnTopOfDeck(opponent.BattleZone.Permanents.Single(), duel);
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                opponent.PutFromBattleZoneOnTopOfDeck(duel.GetPermanent((decision as GuidDecision).Decision.Single()), duel);
                return null;
            }
        }
    }
}
