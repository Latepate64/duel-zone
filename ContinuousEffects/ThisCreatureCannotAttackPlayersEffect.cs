using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ThisCreatureCannotAttackPlayersEffect : ContinuousEffect, ICannotAttackPlayersEffect
{
    public ThisCreatureCannotAttackPlayersEffect() : base()
    {
    }

    public bool CannotAttackPlayers(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature);
    }

    public override ContinuousEffect Copy()
    {
        return new ThisCreatureCannotAttackPlayersEffect();
    }

    public override string ToString()
    {
        return "This creature can't attack players.";
    }
}
