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

        public override void Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new PutCardsFromYourManaZoneIntoYourGraveyard(Amount), new YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect(Amount) })
            {
                effect.Apply(game, source);
            }
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
