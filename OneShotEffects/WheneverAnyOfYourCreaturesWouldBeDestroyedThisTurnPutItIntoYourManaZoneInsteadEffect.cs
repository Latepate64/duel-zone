using Interfaces;

namespace OneShotEffects;

public sealed class WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect : OneShotEffect
{
    public WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect()
    {
    }

    public WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect(
        IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability, new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
    }

    public override IOneShotEffect Copy()
    {
        return new WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect(this);
    }

    public override string ToString()
    {
        return "Whenever any of your creatures would be destroyed this turn, put it into your mana zone instead.";
    }
}
