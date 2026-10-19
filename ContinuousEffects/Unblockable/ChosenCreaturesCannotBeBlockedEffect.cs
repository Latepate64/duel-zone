using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public sealed class ChosenCreaturesCannotBeBlockedEffect :
    ContinuousEffect, IUnblockableEffect
{
    private readonly ICreature[] creatures;

    public ChosenCreaturesCannotBeBlockedEffect(params ICreature[] creature) : base()
    {
        creatures = creature;
    }

    public ChosenCreaturesCannotBeBlockedEffect(
        ChosenCreaturesCannotBeBlockedEffect effect) : base(effect)
    {
        creatures = [.. effect.creatures];
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        return creatures.Any(x => x.Id == attacker.Id);
    }

    public override IContinuousEffect Copy()
    {
        return new ChosenCreaturesCannotBeBlockedEffect(this);
    }
}