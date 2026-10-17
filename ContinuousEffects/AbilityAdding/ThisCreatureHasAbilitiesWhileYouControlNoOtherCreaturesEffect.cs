using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffect
    : ContinuousEffect, IAbilityAddingEffect
{
    private readonly IStaticAbilityWithIntegerFactory abilityWithIntegerFactory;
    private readonly IStaticAbilityFactory abilityFactory;
    private readonly int power;

    internal ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffect(
        IStaticAbilityWithIntegerFactory abilityWithIntegerFactory,
        IStaticAbilityFactory abilityFactory,
        int power) : base()
    {
        this.abilityWithIntegerFactory = abilityWithIntegerFactory;
        this.abilityFactory = abilityFactory;
        this.power = power;
    }

    private ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffect(
        ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffect effect) : base(effect)
    {
        abilityWithIntegerFactory = effect.abilityWithIntegerFactory;
        abilityFactory = effect.abilityFactory;
        power = effect.power;
    }

    public void AddAbility(IGame game)
    {
        if (!game.BattleZone.GetCreatures(Controller.Id).Any(x => x != Source))
        {
            Source.AddGrantedAbility(abilityWithIntegerFactory.Create(power));
            Source.AddGrantedAbility(abilityFactory.Create());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffect(this);
    }
}
