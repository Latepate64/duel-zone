using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM06;

public sealed class CliffcrushGiantEffect : ContinuousEffect, ICannotAttackEffect
{
    public CliffcrushGiantEffect()
    {
    }

    public CliffcrushGiantEffect(CliffcrushGiantEffect effect) : base(effect)
    {
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature) && game.BattleZone.GetOtherUntappedCreatures(Controller.Id, Source.Id).Any();
    }

    public override IContinuousEffect Copy()
    {
        return new CliffcrushGiantEffect(this);
    }

    public override string ToString()
    {
        return "While you have any other untapped creatures in the battle zone, this creature can't attack.";
    }
}
