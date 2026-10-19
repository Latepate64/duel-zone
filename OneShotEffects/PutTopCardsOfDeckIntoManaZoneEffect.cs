using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Put the top x cards of your deck into your mana zone.
/// </summary>
public sealed class PutTopCardsOfDeckIntoManaZoneEffect : OneShotEffect
{
    private readonly int amount;

    public PutTopCardsOfDeckIntoManaZoneEffect(int amount) : base()
    {
        this.amount = amount;
    }

    private PutTopCardsOfDeckIntoManaZoneEffect(
        PutTopCardsOfDeckIntoManaZoneEffect effect)
    {
        amount = effect.amount;
    }

    public override void Apply(IGame game)
    {
        Controller.PutFromTopOfDeckIntoManaZone(game, amount, Ability);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not PutTopCardsOfDeckIntoManaZoneEffect effect) return false;
        if (amount != effect.amount) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), amount);
    }

    public override IOneShotEffect Copy()
    {
        return new PutTopCardsOfDeckIntoManaZoneEffect(this);
    }
}
