using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class DestroyMaxPowerCreature : DestroyEffect
{
    private readonly int _power;

    public DestroyMaxPowerCreature(int power) : base(1, 1, true)
    {
        _power = power;
    }

    public DestroyMaxPowerCreature(DestroyMaxPowerCreature effect) : base(effect)
    {
        _power = effect._power;
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyMaxPowerCreature(this);
    }

    public override string ToString()
    {
        return $"Destroy a creature that has power {_power} or less.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByAnyone(
            game, GetOpponent(game).Id).Where(x => x.Power <= _power);
    }
}
