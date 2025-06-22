using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class YouMayUntapThisCreatureEffect : ControllerMayUntapCreatureEffect
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
        return new ICard[] { Ability.Source };
    }
}
