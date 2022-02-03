using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    public class ControllerMayUntapCreatureEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        public ControllerMayUntapCreatureEffect(CardFilter filter)
        {
            Filter = filter;
        }

        public ControllerMayUntapCreatureEffect(ControllerMayUntapCreatureEffect effect)
        {
            Filter = effect.Filter;
        }

        public override OneShotEffect Copy()
        {
            return new ControllerMayUntapCreatureEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player.Choose(new YesNoChoice(source.Owner)).Decision)
            {
                foreach (var card in game.GetAllCards().Where(x => Filter.Applies(x, game, player)))
                {
                    card.Tapped = false;
                }
            }
        }
    }
}
