using Interfaces;

namespace OneShotEffects;

public abstract class CardMovingAreaOfEffect : OneShotAreaOfEffect
{
    public ZoneType SourceZone { get; }
    public ZoneType DestinationZone { get; }

    protected CardMovingAreaOfEffect(ZoneType source, ZoneType destination) : base()
    {
        SourceZone = source;
        DestinationZone = destination;
    }

    protected CardMovingAreaOfEffect(CardMovingAreaOfEffect effect) : base(effect)
    {
        SourceZone = effect.SourceZone;
        DestinationZone = effect.DestinationZone;
    }

    public override void Apply(IGame game)
    {
        var cards = GetAffectedCards(game, Ability).ToArray();
        _ = game.Move(Ability, SourceZone, DestinationZone, cards);
    }
}
