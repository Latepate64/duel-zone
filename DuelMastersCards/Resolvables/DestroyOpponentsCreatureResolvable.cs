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

        public override void Resolve(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var permanents = duel.GetOpponent(player).BattleZone.GetChoosableCreatures(duel).Where(x => Filters.All(f => f.Applies(x, duel)));
            if (permanents.Count() > 1)
            {
                var dec = player.Choose(new GuidSelection(Controller, permanents, 1, 1));
                duel.Destroy(dec.Decision.Select(x => duel.GetPermanent(x)));
            }
            else if (permanents.Any())
            {
                duel.Destroy(permanents);
            }
        }
    }
}
