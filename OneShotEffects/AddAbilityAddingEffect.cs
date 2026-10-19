using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddAbilityAddingEffect : OneShotEffect
{
    private readonly IContinuousEffectWithStaticAbilityFactoryFactory effectFactory;
    private readonly ICardFilter filter;
    private readonly IStaticAbilityFactory abilityFactory;
    private readonly IDuration duration;

    public AddAbilityAddingEffect(
        IContinuousEffectWithStaticAbilityFactoryFactory effectFactory, 
        ICardFilter filter,
        IStaticAbilityFactory abilityFactory,
        IDuration duration)
    {
        this.effectFactory = effectFactory;
        this.filter = filter;
        this.abilityFactory = abilityFactory;
        this.duration = duration;
    }

    public AddAbilityAddingEffect(AddAbilityAddingEffect effect) : base(effect)
    {
        effectFactory = effect.effectFactory;
        filter = effect.filter.Copy();
        abilityFactory = effect.abilityFactory;
        duration = effect.duration;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        var effect = effectFactory.Create(abilityFactory, [..creatures]);
        game.AddContinuousEffects(Ability, duration, effect);
    }

    public override IOneShotEffect Copy()
    {
        return new AddAbilityAddingEffect(this);
    }
}
