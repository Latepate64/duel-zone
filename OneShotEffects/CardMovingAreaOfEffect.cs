using System.ComponentModel;
using Interfaces;
using Interfaces.Zones;

namespace OneShotEffects;

public sealed class CardMovingAreaOfEffect : OneShotEffect
{
    public ZoneType SourceZone { get; }
    public ZoneType DestinationZone { get; }
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;
    private readonly bool excludeSource;

    public CardMovingAreaOfEffect(
        ZoneType source,
        ZoneType destination,
        ICardFilter filter,
        SelectionRange selectionRange,
        bool excludeSource = false) : base()
    {
        SourceZone = source;
        DestinationZone = destination;
        this.filter = filter;
        this.selectionRange = selectionRange;
        this.excludeSource = excludeSource;
    }

    private CardMovingAreaOfEffect(CardMovingAreaOfEffect effect) : base(effect)
    {
        SourceZone = effect.SourceZone;
        DestinationZone = effect.DestinationZone;
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
        excludeSource = effect.excludeSource;
    }

    public override void Apply(IGame game)
    {
        var cards = GetAffectedCards(game).ToArray();
        _ = game.Move(Ability, SourceZone, DestinationZone, cards);
    }

    private List<ICard> GetAffectedCards(IGame game)
    {
        List<ICard> cards = [];
        cards.AddRange(
            GetCards(game, Applier, SelectionRange.OwnCards));
        cards.AddRange(
            GetCards(game, Applier.Opponent, SelectionRange.OpponentsCards));
        return cards;
    }

    private List<ICard> GetCards(
        IGame game, IPlayerV2 player, SelectionRange range)
    {
        List<ICard> cards = [];
        if (selectionRange == range ||
            selectionRange == SelectionRange.AllCards)
        {
            if (SourceZone == ZoneType.BattleZone)
            {
                cards.AddRange(
                    game.BattleZone.GetCreaturesControlledByPlayer(
                        player, filter));
            }
            else
            {
                cards.AddRange(GetZone(player).GetCards(filter));
            }
        }
        return cards;
    }

    public override IOneShotEffect Copy()
    {
        return new CardMovingAreaOfEffect(this);
    }

    private IZone GetZone(IPlayerV2 player)
    {
        return SourceZone switch
        {
            ZoneType.Deck => player.Deck,
            ZoneType.Graveyard => player.Graveyard,
            ZoneType.Hand => player.Hand,
            ZoneType.ManaZone => player.ManaZone,
            ZoneType.ShieldZone => player.ShieldZone,
            _ => throw new InvalidEnumArgumentException()
        };
    }
}
