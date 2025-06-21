using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public abstract class ControllerMayUntapCreatureEffect : OneShotEffect
{
    protected ControllerMayUntapCreatureEffect()
    {
    }

    protected ControllerMayUntapCreatureEffect(ControllerMayUntapCreatureEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            Controller.Untap(game, [.. GetSelectableCards(game, Ability)]);
        }
    }

    protected abstract IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source);
}
