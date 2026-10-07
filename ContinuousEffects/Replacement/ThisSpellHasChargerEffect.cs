using GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

public sealed class ThisSpellHasChargerEffect : ReplacementEffect, IChargerEffect
{
    public ThisSpellHasChargerEffect() : base()
    {
    }

    public ThisSpellHasChargerEffect(ThisSpellHasChargerEffect effect) : base(effect)
    {
    }

    public bool Applies(ICard card, IGame game)
    {
        return IsSourceOfAbility(card);
    }

    public override IContinuousEffect Copy()
    {
        return new ThisSpellHasChargerEffect(this);
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is ICardMovedEvent e && e.Source == ZoneType.SpellStack && e.Destination == ZoneType.Graveyard && e.CardInSourceZone == Source.Id;
    }

    public override string ToString()
    {
        return "Charger";
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }
}
