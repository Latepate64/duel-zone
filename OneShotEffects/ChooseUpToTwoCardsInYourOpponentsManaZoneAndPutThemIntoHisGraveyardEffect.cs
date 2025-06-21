using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect : ManaBurnEffect
{
    public ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect() : base(0, 2, true)
    {
    }

    public ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(
        ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(this);
    }

    public override string ToString()
    {
        return $"Choose up to {Maximum} cards in your opponent's mana zone and put them into his graveyard.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).ManaZone.Cards;
    }
}
