using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect : OneShotEffect
{
    private readonly ICardFilter filter;
    private readonly IContinuousEffect continuousEffect;
    private readonly IDuration duration;

    public YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect(
        ICardFilter filter,
        IContinuousEffect continuousEffect,
        IDuration duration)
    {
        this.filter = filter;
        this.continuousEffect = continuousEffect;
        this.duration = duration;
    }

    public YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect(
        YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        continuousEffect = effect.continuousEffect;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var source = (ICreature)Source!;
        var creature = Controller.ChooseCardOptionally(
            game.BattleZone.GetOtherCreaturesControlledByPlayer(source, filter),
            ToString());
        if (creature != null)
        {
            game.Destroy(Ability, source);
            game.AddContinuousEffects(Ability, duration, continuousEffect);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect(this);
    }
}
