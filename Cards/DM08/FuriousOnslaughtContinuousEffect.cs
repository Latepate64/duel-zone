using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM08;

public sealed class FuriousOnslaughtContinuousEffect : UntilEndOfTurnEffect, IRaceAddingEffect, IPowerModifyingEffect,
    IAbilityAddingEffect
{
    private readonly List<ICreature> _cards;

    public FuriousOnslaughtContinuousEffect(List<ICreature> cards)
    {
        _cards = cards;
    }

    public FuriousOnslaughtContinuousEffect(FuriousOnslaughtContinuousEffect effect) : base(effect)
    {
        _cards = [.. effect._cards];
    }

    public void AddAbility(IGame game)
    {
        _cards.ForEach(x => x.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect())));
    }

    public void AddRace(IGame game)
    {
        _cards.ForEach(x => x.AddGrantedRace(Race.ArmoredDragon));
    }

    public override IContinuousEffect Copy()
    {
        return new FuriousOnslaughtContinuousEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        _cards.ForEach(x => x.IncreasePower(4000));
    }

    public override string ToString()
    {
        return $"{_cards} is an Armored Dragon in addition to its other races, gets +4000 power, and has \"double breaker.\"";
    }
}
