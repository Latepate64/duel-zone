using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActionResponses
{
    public class CreatureSelectionResponse : PlayerActionResponse
    {
        public Collection<Creature> SelectedCreatures { get; } = new Collection<Creature>();

        public CreatureSelectionResponse() { }

        public CreatureSelectionResponse(Collection<Creature> selectedCreatures)
        {
            SelectedCreatures = selectedCreatures;
        }
    }
}
