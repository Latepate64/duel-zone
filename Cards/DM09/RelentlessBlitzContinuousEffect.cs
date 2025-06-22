using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09;

public class RelentlessBlitzContinuousEffect : UntilEndOfTurnEffect, ICanAttackUntappedCreaturesEffect,
    IUnblockableEffect
{
    private readonly Race _race;

    public RelentlessBlitzContinuousEffect(Race race)
    {
        _race = race;
    }

    public RelentlessBlitzContinuousEffect(RelentlessBlitzContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return attacker.HasRace(_race);
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return attacker.HasRace(_race) && targetOfAttack is Card;
    }

    public override IContinuousEffect Copy()
    {
        return new RelentlessBlitzContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"This turn, {_race}s can attack untapped creatures and can't be blocked while attacking a creature.";
    }
}
