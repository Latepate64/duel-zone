using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class CreatureIntegerAffectingContinuousEffectAddingEffect : OneShotEffect
{
    private readonly int number;
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public CreatureIntegerAffectingContinuousEffectAddingEffect(
        int number,
        IContinuousEffectWithCreaturesAndIntegerFactory factory) : base()
    {
        this.number = number;
        this.factory = factory;
    }

    public CreatureIntegerAffectingContinuousEffectAddingEffect(
        CreatureIntegerAffectingContinuousEffectAddingEffect effect) : base(
            effect)
    {
        number = effect.number;
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id);
        game.AddContinuousEffects(
            Ability,
            factory.Create(number, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new CreatureIntegerAffectingContinuousEffectAddingEffect(this);
    }
}
