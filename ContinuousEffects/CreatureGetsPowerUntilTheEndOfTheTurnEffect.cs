using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class CreatureGetsPowerUntilTheEndOfTheTurnEffect : UntilEndOfTurnEffect, IPowerModifyingEffect
{
    private readonly ICreature _creature;
    private readonly int _power;

    public CreatureGetsPowerUntilTheEndOfTheTurnEffect(CreatureGetsPowerUntilTheEndOfTheTurnEffect effect) : base(
        effect)
    {
        _creature = effect._creature;
        _power = effect._power;
    }

    public CreatureGetsPowerUntilTheEndOfTheTurnEffect(ICreature creature, int power)
    {
        _creature = creature;
        _power = power;
    }

    public override IContinuousEffect Copy()
    {
        return new CreatureGetsPowerUntilTheEndOfTheTurnEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        _creature.IncreasePower(_power);
    }

    public override string ToString()
    {
        return $"{_creature} has +{_power} until the end of the turn.";
    }
}
