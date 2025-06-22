using Engine.Abilities;
using Interfaces;

namespace Cards.DM08;

public class MarineScrambleEffect : OneShotEffect
{
    public MarineScrambleEffect() : base()
    {
    }

    public MarineScrambleEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new YourCreaturesCannotBeBlockedThisTurnEffect());
    }

    public override IOneShotEffect Copy()
    {
        return new MarineScrambleEffect(this);
    }

    public override string ToString()
    {
        return "Your creatures in the battle zone can't be blocked this turn.";
    }
}
