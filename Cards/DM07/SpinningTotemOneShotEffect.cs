using TriggeredAbilities;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

public class SpinningTotemOneShotEffect : OneShotEffect
{
    public SpinningTotemOneShotEffect()
    {
    }

    public SpinningTotemOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(
            new SpinningTotemTriggeredAbility(), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new SpinningTotemOneShotEffect(this);
    }

    public override string ToString()
    {
        return "This turn, whenever any of your nature creatures is attacking your opponent and becomes blocked, it breaks one of his shields.";
    }
}
