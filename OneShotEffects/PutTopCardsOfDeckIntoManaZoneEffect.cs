using Interfaces;

namespace OneShotEffects;

public abstract class PutTopCardsOfDeckIntoManaZoneEffect : OneShotEffect
{
    public int Amount { get; }

    protected PutTopCardsOfDeckIntoManaZoneEffect(int amount) : base()
    {
        Amount = amount;
    }

    protected PutTopCardsOfDeckIntoManaZoneEffect(PutTopCardsOfDeckIntoManaZoneEffect effect)
    {
        Amount = effect.Amount;
    }

    public override void Apply(IGame game)
    {
        Controller.PutFromTopOfDeckIntoManaZone(game, Amount, Ability);
    }

    public override string ToString()
    {
        return $"Put the top {((Amount == 1) ? "card" : $"{Amount} cards")} of your deck into your mana zone.";
    }
}
