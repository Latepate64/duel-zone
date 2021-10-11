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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
                var permanents = opponent.BattleZone.GetChoosableCreatures(duel).Where(x => Filters.All(f => f.Applies(x, duel)));
                if (permanents.Count() > 1)
                {
                    return new GuidSelection(Controller, permanents, 1, 1);
                }
                else if (permanents.Any())
                {
                    duel.Destroy(permanents.Single());
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                duel.Destroy(duel.GetPermanent((decision as GuidDecision).Decision.Single()));
                return null;
            }
        }
    }
}
