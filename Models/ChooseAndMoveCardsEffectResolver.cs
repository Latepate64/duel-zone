using Interfaces;

namespace Models;

public class ChooseAndMoveCardsEffectResolver(
    IGame game) : EventResolver<ChooseAndMoveCardsEffect, IGameEvent>
{
    public ICard[]? ChosenCards { get; set; }
    private readonly IGame game = game;

    public override IEnumerable<IGameEvent> Resolve(
        IGameState state, IPlayer applier, ChooseAndMoveCardsEffect effect)
    {
        if (ChosenCards != null)
        {
            var events = ChosenCards.Select(
                x => new MoveCardEvent(x, effect.Source, effect.Destination));
            Finished = true;
            return events;
        }
        var cards = new List<ICard>();
        if (effect.Source == ZoneType.Battlezone)
        {
            if (effect.SelectionRange == SelectionRange.Opponent)
            {
                cards.AddRange(state.BattleZone.GetOpponentsChoosableCreatures(
                    applier, effect.CardFilter, game));
            }
        }
        if (cards.Count == 0)
        {
            Finished = true;
            return [];
        }
        return [new ChooseCardsEvent(effect.Minimum, effect.Maximum, [.. cards])];
    }
}
