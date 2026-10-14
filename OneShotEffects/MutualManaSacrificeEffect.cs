using Interfaces;

namespace OneShotEffects;

public sealed class MutualManaSacrificeEffect : OneShotEffect
{
    private readonly int amount;

    public MutualManaSacrificeEffect(int amount)
    {
        this.amount = amount;
    }

    private MutualManaSacrificeEffect(
        MutualManaSacrificeEffect effect) : base(effect)
    {
        amount = effect.amount;
    }

    public override void Apply(IGame game)
    {
        var cards = game.Players.SelectMany(
            x => x.ChooseCards(x.ManaZone.Cards, amount, amount, ToString()));
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, [.. cards]);
    }

    public override IOneShotEffect Copy()
    {
        return new MutualManaSacrificeEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(this)) return false;
        if (obj is not MutualManaSacrificeEffect effect) return false;
        if (amount != effect.amount) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), amount);
    }
}
