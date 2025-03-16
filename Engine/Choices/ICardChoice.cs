using System.Collections.Generic;

namespace Engine.Choices;

public interface ICardChoice : IChoice
{
    bool CanBeChosenAutomatically { get; }
    IEnumerable<ICard> Cards { get; set; }
    IEnumerable<ICard> Choice { get; set; }
    ICardChoiceMode Mode { get; set; }

    IEnumerable<ICard> ChooseAutomatically();
}