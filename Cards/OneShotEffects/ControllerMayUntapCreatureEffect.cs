using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class ControllerMayUntapCreatureEffect : OneShotEffect
    {
        protected ControllerMayUntapCreatureEffect()
        {
        }

        protected ControllerMayUntapCreatureEffect(ControllerMayUntapCreatureEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).Choose(new YesNoChoice(source.Controller, ToString()), game).Decision)
            {
                source.GetController(game).Untap(game, GetSelectableCards(game, source).ToArray());
                return true;
            }
            else
            {
                return false;
            }
        }

        protected abstract IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source);
    }

    class YouMayUntapThisCreatureEffect : ControllerMayUntapCreatureEffect
    {
        public YouMayUntapThisCreatureEffect() : base()
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

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return new ICard[] { game.GetCard(source.Source) };
        }
    }
}
