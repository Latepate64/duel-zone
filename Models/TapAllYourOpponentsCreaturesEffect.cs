namespace Models;

public partial class TapAllYourOpponentsCreaturesEffect : OneShotEffect
{
    public override TapAllYourOpponentsCreaturesEffect Copy()
    {
        return new TapAllYourOpponentsCreaturesEffect
        {
            CardFilter = CardFilter.Copy() as CardFilter
        };
    }

    public override bool Equals(object? obj)
    {
        if (obj is not TapAllYourOpponentsCreaturesEffect effect) return false;
        if (!CardFilter.Equals(effect.CardFilter)) return false;
        return true;
    }
}