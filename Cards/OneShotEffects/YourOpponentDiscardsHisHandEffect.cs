using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YourOpponentDiscardsHisHandEffect : CardMovingAreaOfEffect
    {
        public YourOpponentDiscardsHisHandEffect() : base(ZoneType.Hand, ZoneType.Graveyard)
        {
        }

        public YourOpponentDiscardsHisHandEffect(CardMovingAreaOfEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YourOpponentDiscardsHisHandEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent discards his hand.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Applier.Opponent.Hand.Cards;
        }
    }
}