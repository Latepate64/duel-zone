using Interfaces;
using Interfaces.Choices;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices;

public sealed class ApocalypseViseChoiceMode : ICardChoiceMode<ICreature>
{
    public bool CanBeChosenAutomatically(IEnumerable<ICreature> cards)
    {
        return !cards.Any() || cards.All(x => x.Power > 8000);
    }

    public IEnumerable<ICreature> ChooseAutomatically(IEnumerable<ICreature> choosableCards)
    {
        return [];
    }

    public bool IsValid(IEnumerable<ICreature> chosenCards)
    {
        return chosenCards.Sum(x => x.Power) <= 8000;
    }
}
