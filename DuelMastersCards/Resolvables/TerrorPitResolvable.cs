using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class TerrorPitResolvable : Resolvable
    {
        public TerrorPitResolvable()
        {
        }

        public TerrorPitResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new TerrorPitResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // Destroy one of your opponent's creatures.
            if (decision == null)
            {
                var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
                if (opponent.BattleZone.Permanents.Count > 0)
                {
                    return new GuidSelection(Controller, opponent.BattleZone.Permanents, 1, 1);
                }
                else if (opponent.BattleZone.Permanents.Any())
                {
                    duel.Destroy(opponent.BattleZone.Permanents.Single());
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                duel.Destroy((decision as GuidDecision).Decision.Select(x => duel.GetPermanent(x)).Single());
                return null;
            }
        }
    }
}
