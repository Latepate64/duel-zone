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

        public override void Apply(Game game)
        {
            var player = game.GetPlayer(Controller);
            var creatures = game.GetOpponent(player).BattleZone.GetChoosableCreatures(game).Where(x => Filters.All(f => f.Applies(x, game)));
            if (creatures.Count() > 1)
            {
                var dec = player.Choose(new GuidSelection(Controller, creatures, 1, 1));
                game.Destroy(dec.Decision.Select(x => game.GetCard(x)));
            }
            else if (creatures.Any())
            {
                game.Destroy(creatures);
            }
        }
    }
}
