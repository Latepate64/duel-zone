using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class YourCreaturesHaveRaceGetPowerAndHaveAbilityEffect : UntilEndOfTurnEffect,
    IRaceAddingEffect, IPowerModifyingEffect, IAbilityAddingEffect
{
    private readonly Race race;
    private readonly int power;
    private readonly IStaticAbilityFactory factory;
    private readonly List<ICreature> _cards;

    public YourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(
        Race race,
        int power,
        IStaticAbilityFactory factory,
        List<ICreature> cards)
    {
        this.race = race;
        this.power = power;
        this.factory = factory;
        _cards = cards;
    }

    private YourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(
        YourCreaturesHaveRaceGetPowerAndHaveAbilityEffect effect) : base(effect)
    {
        race = effect.race;
        power = effect.power;
        factory = effect.factory;
        _cards = [.. effect._cards];
    }

    public void AddAbility(IGame game)
    {
        _cards.ForEach(x => x.AddGrantedAbility(factory.Create()));
    }

    public void AddRace(IGame game)
    {
        _cards.ForEach(x => x.AddGrantedRace(race));
    }

    public override IContinuousEffect Copy()
    {
        return new YourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        _cards.ForEach(x => x.IncreasePower(power));
    }
}
