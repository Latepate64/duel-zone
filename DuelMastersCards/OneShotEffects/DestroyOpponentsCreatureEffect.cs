using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class DestroyOpponentsCreatureEffect : OneShotEffect
    {
        public List<CardFilter> Filters { get; }

        public DestroyOpponentsCreatureEffect(params CardFilter[] cardFilters)
        {
            Filters = cardFilters.ToList();
        }

        public DestroyOpponentsCreatureEffect(DestroyOpponentsCreatureEffect effect) : base(effect)
        {
            Filters = effect.Filters;
        }

        public override OneShotEffect Copy()
        {
            return new DestroyOpponentsCreatureEffect(this);
        }

        public override void Apply(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var creatures = duel.GetOpponent(player).BattleZone.GetChoosableCreatures(duel).Where(x => Filters.All(f => f.Applies(x, duel)));
            if (creatures.Count() > 1)
            {
                var dec = player.Choose(new GuidSelection(Controller, creatures, 1, 1));
                duel.Destroy(dec.Decision.Select(x => duel.GetCard(x)));
            }
            else if (creatures.Any())
            {
                duel.Destroy(creatures);
            }
        }
    }
}
