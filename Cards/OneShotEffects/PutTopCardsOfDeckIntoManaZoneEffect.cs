using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class PutTopCardsOfDeckIntoManaZoneEffect : OneShotEffect
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

    class PutTopCardOfDeckIntoManaZoneEffect : PutTopCardsOfDeckIntoManaZoneEffect
    {
        public PutTopCardOfDeckIntoManaZoneEffect() : base(1)
        {
        }

        public PutTopCardOfDeckIntoManaZoneEffect(PutTopCardsOfDeckIntoManaZoneEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PutTopCardOfDeckIntoManaZoneEffect(this);
        }
    }

    class PutTopTwoCardOfDeckIntoManaZoneEffect : PutTopCardsOfDeckIntoManaZoneEffect
    {
        public PutTopTwoCardOfDeckIntoManaZoneEffect() : base(2)
        {
        }

        public PutTopTwoCardOfDeckIntoManaZoneEffect(PutTopTwoCardOfDeckIntoManaZoneEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PutTopTwoCardOfDeckIntoManaZoneEffect(this);
        }
    }
}
