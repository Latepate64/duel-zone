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

        public DestroyOpponentsCreatureEffect(DestroyOpponentsCreatureEffect effect)
        {
            Filters = effect.Filters;
        }

        public override OneShotEffect Copy()
        {
            return new DestroyOpponentsCreatureEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            var creatures = game.BattleZone.GetChoosableCreatures(game, game.GetOpponent(source.Owner)).Where(x => Filters.All(f => f.Applies(x, game, source.Owner)));
            if (creatures.Count() > 1)
            {
                var dec = player.Choose(new GuidSelection(source.Owner, creatures, 1, 1));
                game.Destroy(dec.Decision.Select(x => game.GetCard(x)));
            }
            else if (creatures.Any())
            {
                game.Destroy(creatures);
            }
        }
    }
}
