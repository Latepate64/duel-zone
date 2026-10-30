using Interfaces;

namespace Models;

public class ChooseCardsEventResolver : ChoiceResolver<ChooseCardsEvent, IGameEvent>
{
    public override IEnumerable<IGameEvent> Resolve(
        IGameState state, IPlayer applier, ChooseCardsEvent gameEvent)
    {
        if (gameEvent.ChoosableCards.Length == 0)
        {
            Finished = true;
            return [];
        }
        return [];
    }

    public override void Validate(ChooseCardsEvent original, ChooseCardsEvent proposed)
    {
        var proposedIds = proposed.Chosen.Select(x => x.PhysicalId).Distinct();
        if (proposedIds.Count() < original.Minimum) throw new Exception();
        if (proposedIds.Count() > original.Maximum) throw new Exception();
        var choosableIds = original.ChoosableCards.Select(x => x.PhysicalId);
        if (proposedIds.Any(x => !choosableIds.Contains(x))) throw new Exception();
    }
}