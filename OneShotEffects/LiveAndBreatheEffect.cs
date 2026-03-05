using TriggeredAbilities;
using Interfaces;

namespace OneShotEffects;

public sealed class LiveAndBreatheEffect : OneShotEffect
{
    public LiveAndBreatheEffect()
    {
    }

    public LiveAndBreatheEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(
            new LiveAndBreatheAbility(), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new LiveAndBreatheEffect(this);
    }

    public override string ToString()
    {
        return "Whenever you summon a creature this turn, search your deck. You may take a creature from your deck that has the same name as that creature and put it into the battle zone. Then shuffle your deck.";
    }
}
