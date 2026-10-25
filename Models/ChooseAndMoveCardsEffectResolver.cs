using Interfaces;

namespace Models;

public class ChooseAndMoveCardsEffectResolver(IGame game) : EventResolver<ChooseAndMoveCardsEffect, IGameEvent>
{
    private readonly IGame game = game;

    public override IEnumerable<IGameEvent> Resolve(
        IGameState state, IPlayer applier, ChooseAndMoveCardsEffect effect)
    {
        var cards = new List<ICard>();
        if (effect.Source == ZoneType.Battlezone)
        {
            if (effect.SelectionRange == SelectionRange.Opponent)
            {
                cards.AddRange(state.BattleZone.GetOpponentsChoosableCreatures(
                    applier, effect.CardFilter, game));
            }
        }
        if (cards.Count == 0) return [];
        if (cards.Count <= effect.Minimum)
        {
            return cards.Select(x => new MoveCardEvent(x, effect.Source, effect.Destination));
        }
        throw new NotImplementedException("Let applier choose");
    }
}
