using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Put the top x cards of your deck into your mana zone.
/// </summary>
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

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not PutTopCardsOfDeckIntoManaZoneEffect effect) return false;
        if (Amount != effect.Amount) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Amount);
    }
}
