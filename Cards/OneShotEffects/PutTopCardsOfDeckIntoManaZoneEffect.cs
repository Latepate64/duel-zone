using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class PutTopCardsOfDeckIntoManaZoneEffect : OneShotEffect
    {
        public int Amount { get; }

        public PutTopCardsOfDeckIntoManaZoneEffect(int amount) : base()
        {
            Amount = amount;
        }

        public PutTopCardsOfDeckIntoManaZoneEffect(PutTopCardsOfDeckIntoManaZoneEffect effect)
        {
            Amount = effect.Amount;
        }

        public override IOneShotEffect Copy()
        {
            return new PutTopCardsOfDeckIntoManaZoneEffect(this);
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
}
