using Interfaces;

namespace OneShotEffects;

public abstract class CardSelectionEffect<T> : OneShotEffect where T : ICard
{
    public int Minimum { get; }
    public int Maximum { get; }
    public bool ControllerChooses { get; }

    protected CardSelectionEffect(int minimum, int maximum, bool controllerChooses)
    {
        Minimum = minimum;
        Maximum = maximum;
        ControllerChooses = controllerChooses;
    }

    protected CardSelectionEffect(CardSelectionEffect<T> effect) : base(effect)
    {
        Minimum = effect.Minimum;
        Maximum = effect.Maximum;
        ControllerChooses = effect.ControllerChooses;
    }

    public override void Apply(IGame game)
    {
        var cards = GetSelectableCards(game, Ability);
        var player = ControllerChooses ? Controller : GetOpponent(game);
        if (player != null)
        {
            var chosen = player.ChooseCards(cards, Minimum, Math.Min(Maximum, cards.Count()), ToString());
            if (chosen != null)
            {
                Apply(game, Ability, [.. chosen]);
            }
        }
    }

    protected abstract void Apply(IGame game, IAbility source, params T[] cards);

    protected abstract IEnumerable<T> GetSelectableCards(IGame game, IAbility source);

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CardSelectionEffect<T> effect) return false;
        if (!Minimum.Equals(effect.Minimum)) return false;
        if (!Maximum.Equals(effect.Maximum)) return false;
        if (!ControllerChooses.Equals(effect.ControllerChooses)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            base.GetHashCode(),
            Minimum,
            Maximum,
            ControllerChooses
        );
    }
}
