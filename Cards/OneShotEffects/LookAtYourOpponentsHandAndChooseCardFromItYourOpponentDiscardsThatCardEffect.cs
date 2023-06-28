using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect : OneShotEffect
    {
        public LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect()
        {
        }

        public LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            Applier.Look(Applier.Opponent, game, Applier.Opponent.Hand.Cards.ToArray());
            var card = Applier.ChooseCard(Applier.Opponent.Hand.Cards, ToString());
            if (card != null)
            {
                Applier.Opponent.Discard(Ability, game, card);
                Applier.Opponent.Unreveal(card);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect(this);
        }

        public override string ToString()
        {
            return "Look at your opponent's hand and choose a card from it. Your opponent discards that card.";
        }
    }
}