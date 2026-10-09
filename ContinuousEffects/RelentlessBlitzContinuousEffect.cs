using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// This turn, each creature of that race can attack untapped creatures and
/// can't be blocked while attacking a creature.
/// </summary>
public sealed class RelentlessBlitzContinuousEffect : UntilEndOfTurnEffect,
    ICanAttackUntappedCreaturesEffect, IUnblockableEffect
{
    private readonly Race _race;

    public RelentlessBlitzContinuousEffect(Race race)
    {
        _race = race;
    }

    public RelentlessBlitzContinuousEffect(
        RelentlessBlitzContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public bool CanAttackUntappedCreature(ICreature attacker,
        ICreature targetOfAttack, IGame game)
    {
        return attacker.HasRace(_race);
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        return attacker.HasRace(_race) && targetOfAttack is ICreature;
    }

    public override IContinuousEffect Copy()
    {
        return new RelentlessBlitzContinuousEffect(this);
    }
}
