using Engine.Abilities;
using GameEvents;
using Interfaces;

namespace Cards.DM09;

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
        return gameEvent is SpellCastEvent e && e.Player.Id == GetOpponent(game).Id;
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
