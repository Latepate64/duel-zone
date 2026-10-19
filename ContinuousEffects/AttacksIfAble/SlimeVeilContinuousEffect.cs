using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public sealed class SlimeVeilContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    private readonly IPlayer _player;

    public SlimeVeilContinuousEffect(IPlayer player)
    {
        _player = player;
    }

    public SlimeVeilContinuousEffect(SlimeVeilContinuousEffect effect) : base(effect)
    {
        _player = effect._player;
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature.Owner == _player;
    }

    public override IContinuousEffect Copy()
    {
        return new SlimeVeilContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"During {_player}'s next turn, each of his creatures attacks if able.";
    }
}
