using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverYourOpponentCastsSpellAbility : TriggeredAbility
{
    public WheneverYourOpponentCastsSpellAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WheneverYourOpponentCastsSpellAbility(WheneverYourOpponentCastsSpellAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WheneverYourOpponentCastsSpellAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever your opponent casts a spell, {GetEffectText()}";
    }
}
