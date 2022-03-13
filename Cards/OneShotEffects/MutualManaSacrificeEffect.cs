using Cards.CardFilters;
using Engine;
using Engine.Abilities;

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

        public override object Apply(Game game, Ability source)
        {
            foreach (var effect in new OneShotEffect[] { new ManaBurnEffect(new OwnersManaZoneCardFilter(), Amount, Amount, true), new ManaBurnEffect(new OpponentsManaZoneCardFilter(), Amount, Amount, false) })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new MutualManaSacrificeEffect(this);
        }

        public override string ToString()
        {
            return $"Each player chooses 2 cards in his mana zone and puts them into his graveyard.";
        }
    }
}
