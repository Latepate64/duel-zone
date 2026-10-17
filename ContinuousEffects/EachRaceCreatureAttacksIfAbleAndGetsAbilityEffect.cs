using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class EachRaceCreatureAttacksIfAbleAndGetsAbilityEffect : UntilEndOfTurnEffect,
    IAttacksIfAbleEffect, IAbilityAddingEffect
{
    private readonly Race race;
    private readonly IStaticAbilityWithIntegerFactory abilityFactory;
    private readonly int power;

    public EachRaceCreatureAttacksIfAbleAndGetsAbilityEffect(
        Race race,
        IStaticAbilityWithIntegerFactory abilityFactory,
        int power) : base()
    {
        this.race = race;
        this.abilityFactory = abilityFactory;
        this.power = power;
    }

    private EachRaceCreatureAttacksIfAbleAndGetsAbilityEffect(
        EachRaceCreatureAttacksIfAbleAndGetsAbilityEffect effect) : base(effect)
    {
        race = effect.race;
        abilityFactory = effect.abilityFactory;
        power = effect.power;
    }

    public void AddAbility(IGame game)
    {
        game.BattleZone.GetCreatures(race).ToList().ForEach(x => x.AddGrantedAbility(
            abilityFactory.Create(power)));
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature.HasRace(race);
    }

    public override IContinuousEffect Copy()
    {
        return new EachRaceCreatureAttacksIfAbleAndGetsAbilityEffect(this);
    }
}
