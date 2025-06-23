using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class LaserWingEffect : CreatureSelectionEffect
{
    public LaserWingEffect() : base(0, 2, true)
    {
    }

    public LaserWingEffect(LaserWingEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new LaserWingEffect(this);
    }

    public override string ToString()
    {
        return "Choose up to 2 of your creatures in the battle zone. They can't be blocked this turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(Ability, new ChosenCreaturesCannotBeBlockedThisTurnEffect(cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
