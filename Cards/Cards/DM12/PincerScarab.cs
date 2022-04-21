using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class PincerScarab : Creature
    {
        public PincerScarab() : base("Pincer Scarab", 4, 1000, Race.GiantInsect, Civilization.Nature)
        {
            AddStaticAbilities(new PincerScarabEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class PincerScarabEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public PincerScarabEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PincerScarabEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each card in your opponent's hand.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.GetPlayer(game.GetOpponent(Controller.Id)).Hand.Cards.Count();
        }
    }
}
