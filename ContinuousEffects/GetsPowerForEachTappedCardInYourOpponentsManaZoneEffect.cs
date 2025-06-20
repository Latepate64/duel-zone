using Engine;
using Engine.ContinuousEffects;

namespace ContinuousEffects;

public class GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect : PowerModifyingMultiplierEffect
{
    public GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(int power) : base(power)
    {
    }

    public GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(this);
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each tapped card in your opponent's mana zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.GetPlayer(game.GetOpponent(Controller.Id)).ManaZone.TappedCards.Count();
    }
}
