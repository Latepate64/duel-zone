using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System;
using System.Linq;

namespace Cards.Cards.DM01;

public class IocantTheOracleEffect : ContinuousEffect, IPowerModifyingEffect
{
    readonly Race race;
    readonly int power;

    /// <summary>
    /// While you have at least one creature of specific race in the battle
    /// zone, this creature gets additional power.
    /// </summary>
    /// <param name="race">The race of the creature that the player needs to
    /// have in the battle zone.</param>
    /// <param name="power">The amount of power that the creature can
    /// get.</param>
    public IocantTheOracleEffect(Race race, int power) : base()
    {
        this.race = race;
        this.power = power;
    }

    IocantTheOracleEffect(IocantTheOracleEffect effect) : base(effect)
    {
        race = effect.race;
        power = effect.power;
    }

    public override IContinuousEffect Copy()
    {
        return new IocantTheOracleEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        if (game.BattleZone.GetCreatures(Ability.Source.Owner, race).Any())
        {
            Ability.Source.Power += power;
        }
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is IocantTheOracleEffect effect
            && race == effect.race
            && power == effect.power;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), race, power);
    }
}
