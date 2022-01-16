using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class DestroyOpponentsCreatureResolvable : Resolvable
    {
        public List<CardFilter> Filters { get; }

        public DestroyOpponentsCreatureResolvable(params CardFilter[] cardFilters)
        {
            Filters = cardFilters.ToList();
        }

        public DestroyOpponentsCreatureResolvable(DestroyOpponentsCreatureResolvable resolvable) : base(resolvable)
        {
            Filters = resolvable.Filters;
        }

        public override Resolvable Copy()
        {
            return new DestroyOpponentsCreatureResolvable(this);
        }

        public override void Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var permanents = duel.GetOpponent(duel.GetPlayer(Controller)).BattleZone.GetChoosableCreatures(duel).Where(x => Filters.All(f => f.Applies(x, duel)));
                if (permanents.Count() > 1)
                {
                    duel.SetAwaitingChoice(new GuidSelection(Controller, permanents, 1, 1));
                }
                else if (permanents.Any())
                {
                    duel.Destroy(permanents);
                }
            }
            else
            {
                duel.Destroy((decision as GuidDecision).Decision.Select(x => duel.GetPermanent(x)));
            }
        }
    }
}
