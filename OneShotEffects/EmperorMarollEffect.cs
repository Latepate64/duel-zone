using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class EmperorMarollEffect : OneShotEffect
{
    public EmperorMarollEffect()
    {
    }

    public EmperorMarollEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        throw new System.NotImplementedException();
        // game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, (game.CurrentTurn.CurrentPhase as AttackPhase).BlockingCreature);
    }

    public override IOneShotEffect Copy()
    {
        return new EmperorMarollEffect(this);
    }

    public override string ToString()
    {
        return "Return the blocking creature to its owner's hand.";
    }
}
