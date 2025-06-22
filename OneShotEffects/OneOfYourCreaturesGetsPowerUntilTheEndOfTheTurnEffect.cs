using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect : CreatureSelectionEffect, IPowerable
{
    public int Power { get; }

    public OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(
        OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
        Power = effect.Power;
    }

    public OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(int power) : base(1, 1, true)
    {
        Power = power;
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(this);
    }

    public override string ToString()
    {
        return $"One of your creatures gets +{Power} power until the end of the turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
            Power, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
