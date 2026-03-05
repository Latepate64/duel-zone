using Interfaces;

namespace OneShotEffects;

public sealed class ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect : ManaBurnEffect
{
    public ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect() : base(1, 1, true)
    {
    }

    public ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect(ManaBurnEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect(this);
    }

    public override string ToString()
    {
        return "Choose a card in your opponent's mana zone and put it into his graveyard.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).ManaZone.Cards;
    }
}
