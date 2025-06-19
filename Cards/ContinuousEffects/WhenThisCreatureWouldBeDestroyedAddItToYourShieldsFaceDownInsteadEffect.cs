using Effects.Continuous;
using Engine;
using Engine.GameEvents;

namespace Cards.ContinuousEffects;

public class WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect : DestructionReplacementEffect
{
    public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect() : base()
    {
    }

    public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect(WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new CardMovedEvent(gameEvent as ICardMovedEvent)
        {
            Destination = ZoneType.ShieldZone
        };
    }

    public override ContinuousEffect Copy()
    {
        return new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect(this);
    }

    public override string ToString()
    {
        return "When this creature would be destroyed, add it to your shields face down instead.";
    }

    protected override bool Applies(Creature card, IGame game)
    {
        return IsSourceOfAbility(card);
    }
}
