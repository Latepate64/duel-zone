using CardFilters;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

/// <summary>
/// Whenever one of your creatures that has \"silent skill\" would be destroyed,
/// put it into your hand instead.
/// </summary>
public sealed class MysticMagicianDestroyedEffect :
    WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
{
    private readonly ICardFilter filter = new SilentSkillFilter();

    public MysticMagicianDestroyedEffect()
    {
    }

    public MysticMagicianDestroyedEffect(
        MysticMagicianDestroyedEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new MysticMagicianDestroyedEffect(this);
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return card != null && card.Owner == Controller && filter.Match(card);
    }
}
