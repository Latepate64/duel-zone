using Interfaces;

namespace OneShotEffects;

public abstract class TapChoiceEffect : CreatureSelectionEffect
{
    protected TapChoiceEffect(int minimum, int maximum, bool ownerChooses) : base(minimum, maximum, ownerChooses)
    {
    }

    protected TapChoiceEffect(TapChoiceEffect effect) : base(effect)
    {
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        (ControllerChooses ? Controller : GetOpponent(game)).Tap(game, cards);
    }
}
