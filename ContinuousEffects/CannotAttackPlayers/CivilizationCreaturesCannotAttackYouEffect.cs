using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotAttackPlayers;

public sealed class CivilizationCreaturesCannotAttackYouEffect : ContinuousEffect,
    ICannotAttackPlayersEffect
{
    private readonly Civilization civilization;

    internal CivilizationCreaturesCannotAttackYouEffect(Civilization civilization)
    {
        this.civilization = civilization;
    }

    private CivilizationCreaturesCannotAttackYouEffect(
        CivilizationCreaturesCannotAttackYouEffect effect) : base(effect)
    {
        civilization = effect.civilization;
    }

    public bool CannotAttackPlayers(ICreature attacker, IGame game)
    {
        return attacker.HasCivilization(civilization);
    }

    public override IContinuousEffect Copy()
    {
        return new CivilizationCreaturesCannotAttackYouEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CivilizationCreaturesCannotAttackYouEffect effect) return false;
        if (!civilization.Equals(effect.civilization)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), civilization);
    }
}
