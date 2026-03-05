using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class MiraculousTruceEffect : OneShotEffect
{
    public MiraculousTruceEffect()
    {
    }

    public MiraculousTruceEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var civilization = Controller.ChooseCivilization(ToString());
        game.AddContinuousEffects(Ability, new MiraculousTruceContinuousEffect(civilization, Controller));
    }

    public override IOneShotEffect Copy()
    {
        return new MiraculousTruceEffect(this);
    }

    public override string ToString()
    {
        return "Choose a civilization. Until the start of your next turn, creatures of that civilization can't attack you even if your opponent puts them into the battle zone after you cast this spell.";
    }
}
