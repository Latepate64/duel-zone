using Engine;
using Engine.Abilities;
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

        public override void Apply(IGame game, IAbility source)
        {
            if (GetController(game).ChooseToTakeAction(ToString()))
            {
                GetController(game).Untap(game, GetSelectableCards(game, source).ToArray());
            }
        }

        protected abstract IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source);
    }

    class YouMayUntapThisCreatureEffect : ControllerMayUntapCreatureEffect
    {
        public YouMayUntapThisCreatureEffect() : base()
        {
        }

        public YouMayUntapThisCreatureEffect(ControllerMayUntapCreatureEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayUntapThisCreatureEffect(this);
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
