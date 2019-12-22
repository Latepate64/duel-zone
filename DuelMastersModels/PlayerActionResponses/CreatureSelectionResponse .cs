using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActionResponses
{
    public class CreatureSelectionResponse : PlayerActionResponse
    {
        public ReadOnlyCreatureCollection SelectedCreatures { get; }

        public CreatureSelectionResponse() { }

        public CreatureSelectionResponse(ReadOnlyCreatureCollection selectedCreatures)
        {
            SelectedCreatures = selectedCreatures;
        }
    }
}
