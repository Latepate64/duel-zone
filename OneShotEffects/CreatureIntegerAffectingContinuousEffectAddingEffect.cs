using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class CreatureIntegerAffectingContinuousEffectAddingEffect : OneShotEffect
{
    private readonly int number;
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;
    private readonly IDuration duration;

    public CreatureIntegerAffectingContinuousEffectAddingEffect(
        int number,
        IContinuousEffectWithCreaturesAndIntegerFactory factory,
        IDuration duration) : base()
    {
        this.number = number;
        this.factory = factory;
        this.duration = duration;
    }

    public CreatureIntegerAffectingContinuousEffectAddingEffect(
        CreatureIntegerAffectingContinuousEffectAddingEffect effect) : base(
            effect)
    {
        number = effect.number;
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id);
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(number, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new CreatureIntegerAffectingContinuousEffectAddingEffect(this);
    }
}
