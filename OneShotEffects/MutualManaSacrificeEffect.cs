using Engine;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public abstract class MutualManaSacrificeEffect : OneShotEffect
{
    public int Amount { get; }

    protected MutualManaSacrificeEffect(int amount)
    {
        Amount = amount;
    }

    protected MutualManaSacrificeEffect(MutualManaSacrificeEffect effect) : base(effect)
    {
        Amount = effect.Amount;
    }

    public override void Apply(IGame game)
    {
        var cards = game.Players.SelectMany(x => x.ChooseCards(x.ManaZone.Cards, Amount, Amount, ToString()));
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, [.. cards]);
    }

    public override string ToString()
    {
        return $"Each player chooses {(Amount > 1 ? $"{Amount} cards" : "a card")} in his mana zone and puts {(Amount > 1 ? "them" : "it")} into his graveyard.";
    }
}
