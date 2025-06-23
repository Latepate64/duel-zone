using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10;

public sealed class TauntingSkyterrorEffect : ContinuousEffect, IAttacksIfAbleEffect
{
    public TauntingSkyterrorEffect()
    {
    }

    public TauntingSkyterrorEffect(TauntingSkyterrorEffect effect) : base(effect)
    {
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return Source.Tapped && creature.Owner == GetOpponent(game);
    }

    public override IContinuousEffect Copy()
    {
        return new TauntingSkyterrorEffect(this);
    }

    public override string ToString()
    {
        return "While this creature is tapped during your opponent's turn, each of his creatures attacks if able.";
    }
}
