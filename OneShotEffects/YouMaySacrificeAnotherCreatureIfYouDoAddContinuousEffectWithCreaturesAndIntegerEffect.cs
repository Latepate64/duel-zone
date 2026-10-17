using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectWithCreaturesAndIntegerEffect
    : OneShotEffect
{
    private readonly int power;
    private readonly ICardFilter filter;
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectWithCreaturesAndIntegerEffect(
        int power,
        ICardFilter filter,
        IContinuousEffectWithCreaturesAndIntegerFactory factory)
    {
        this.power = power;
        this.filter = filter;
        this.factory = factory;
    }

    public YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectWithCreaturesAndIntegerEffect(
        YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectWithCreaturesAndIntegerEffect effect) : base(effect)
    {
        power = effect.power;
        filter = effect.filter.Copy();
        factory = effect.factory;
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
            game.AddContinuousEffects(
                Ability,
                factory.Create(power, source));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new YouMaySacrificeAnotherCreatureIfYouDoAddContinuousEffectWithCreaturesAndIntegerEffect(
            this);
    }
}
