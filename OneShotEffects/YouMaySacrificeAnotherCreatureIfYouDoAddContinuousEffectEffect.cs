using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect : OneShotEffect
{
    private readonly ICardFilter filter;
    private readonly IContinuousEffect continuousEffect;

    public YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect(
        ICardFilter filter,
        IContinuousEffect continuousEffect)
    {
        this.filter = filter;
        this.continuousEffect = continuousEffect;
    }

    public YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect(
        YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        continuousEffect = effect.continuousEffect;
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
            game.AddContinuousEffects(Ability, continuousEffect);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectEffect(this);
    }
}
