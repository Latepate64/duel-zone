using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class MutualManaSacrificeEffect : OneShotEffect
    {
        public int Amount { get; }

        public MutualManaSacrificeEffect(int amount)
        {
            Amount = amount;
        }

        public MutualManaSacrificeEffect(MutualManaSacrificeEffect effect)
        {
            Amount = effect.Amount;
        }

        public override void Apply(IGame game)
        {
            var cards = game.Players.SelectMany(x => x.ChooseCards(x.ManaZone.Cards, Amount, Amount, ToString()));
            game.Move(Source, ZoneType.ManaZone, ZoneType.Graveyard, cards.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new MutualManaSacrificeEffect(this);
        }

        public override string ToString()
        {
            return $"Each player chooses {(Amount > 1 ? $"{Amount} cards" : "a card")} in his mana zone and puts {(Amount > 1 ? "them" : "it")} into his graveyard.";
        }
    }
}
