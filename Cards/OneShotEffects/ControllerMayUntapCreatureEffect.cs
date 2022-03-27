using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class ControllerMayUntapCreatureEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        protected ControllerMayUntapCreatureEffect(CardFilter filter)
        {
            Filter = filter;
        }

        protected ControllerMayUntapCreatureEffect(ControllerMayUntapCreatureEffect effect)
        {
            Filter = effect.Filter;
        }

        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Controller);
            if (player.Choose(new YesNoChoice(source.Controller, ToString()), game).Decision)
            {
                player.Untap(game, game.GetAllCards().Where(x => Filter.Applies(x, game, player)).ToArray());
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class YouMayUntapThisCreatureEffect : ControllerMayUntapCreatureEffect
    {
        public YouMayUntapThisCreatureEffect() : base(new TargetFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayUntapThisCreatureEffect();
        }

        public override string ToString()
        {
            return "You may untap this creature.";
        }
    }
}
