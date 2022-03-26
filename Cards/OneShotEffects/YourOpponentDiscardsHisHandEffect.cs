using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YourOpponentDiscardsHisHandEffect : CardMovingAreaOfEffect
    {
        public YourOpponentDiscardsHisHandEffect() : base(ZoneType.Hand, ZoneType.Graveyard, new CardFilters.OpponentsHandCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YourOpponentDiscardsHisHandEffect();
        }

        public override string ToString()
        {
            return "Your opponent discards his hand.";
        }
    }
}