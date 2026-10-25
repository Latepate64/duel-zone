namespace Models;

public partial class ChooseAndMoveCardsEffect : OneShotEffect
{
    public override ChooseAndMoveCardsEffect Copy()
    {
        return new ChooseAndMoveCardsEffect
        {
            CardFilter = CardFilter.Copy() as CardFilter,
            Minimum = Minimum,
            Maximum = Maximum,
            SelectionRange = SelectionRange,
            Source = Source,
            Destination = Destination
        };
    }
}
