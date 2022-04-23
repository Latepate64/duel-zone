using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class MutualManaSacrificeEffect : OneShotEffect
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
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, cards.ToArray());
        }

        public override string ToString()
        {
            return $"Each player chooses {(Amount > 1 ? $"{Amount} cards" : "a card")} in his mana zone and puts {(Amount > 1 ? "them" : "it")} into his graveyard.";
        }
    }

    class MutualSingleManaSacrificeEffect : MutualManaSacrificeEffect
    {
        public MutualSingleManaSacrificeEffect() : base(1)
        {
        }

        public MutualSingleManaSacrificeEffect(MutualManaSacrificeEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MutualSingleManaSacrificeEffect(this);
        }
    }
}
