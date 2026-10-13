using System.ComponentModel;
using Interfaces;
using Interfaces.Zones;

namespace OneShotEffects;

public sealed class CardMovingChoiceEffect : CardSelectionEffect<ICard>
{
    public ZoneType SourceZone { get; }
    public ZoneType DestinationZone { get; }
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;
    private readonly bool excludeSource; 

    public CardMovingChoiceEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        ZoneType source,
        ZoneType destination,
        SelectionRange selectionRange,
        bool excludeSource = false) : base(
            minimum, maximum, controllerChooses)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
        this.excludeSource = excludeSource;
        SourceZone = source;
        DestinationZone = destination;
    }

    private CardMovingChoiceEffect(CardMovingChoiceEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
        excludeSource = effect.excludeSource;
        SourceZone = effect.SourceZone;
        DestinationZone = effect.DestinationZone;
    }

    protected override void Apply(
        IGame game, IAbility source, params ICard[] cards)
    {
        game.Move(Ability, SourceZone, DestinationZone, cards);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (SourceZone == ZoneType.BattleZone)
        {
            var player = ControllerChooses ? Applier : Applier.Opponent;
            return game.BattleZone.GetChoosableCreatures(
                player, 
                filter, 
                game, 
                selectionRange);
        }
        else
        {
            var player = selectionRange switch
            {
                SelectionRange.OwnCreatures when ControllerChooses =>
                    Applier,
                SelectionRange.OwnCreatures when !ControllerChooses =>
                    Applier.Opponent,
                SelectionRange.OpponentsCreatures when ControllerChooses =>
                    Applier.Opponent,
                SelectionRange.OpponentsCreatures when !ControllerChooses =>
                    Applier,
                _ => throw new InvalidEnumArgumentException()
            };
            //TODO: Consider excludeSource
            return GetZone(player).GetCards(filter);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new CardMovingChoiceEffect(this);
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
