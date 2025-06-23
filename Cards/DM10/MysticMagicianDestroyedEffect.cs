using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10;

public sealed class MysticMagicianDestroyedEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
{
    public MysticMagicianDestroyedEffect()
    {
    }

    public MysticMagicianDestroyedEffect(WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(
        effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new MysticMagicianDestroyedEffect(this);
    }

    public override string ToString()
    {
        return "Whenever one of your creatures that has \"silent skill\" would be destroyed, put it into your hand instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return card != null && card.Owner == Controller
            && card.GetAbilities<Engine.Abilities.SilentSkillAbility>().Any();
    }
}
