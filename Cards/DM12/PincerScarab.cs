using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM12
{
    sealed class PincerScarab : Creature
    {
        public PincerScarab() : base("Pincer Scarab", 4, 1000, Race.GiantInsect, Civilization.Nature)
        {
            AddStaticAbilities(new PincerScarabEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    sealed class PincerScarabEffect(int power = 2000) : ContinuousEffects.PowerModifyingMultiplierEffect(power)
    {
        public override IContinuousEffect Copy()
        {
            return new PincerScarabEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each card in your opponent's hand.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.GetPlayer(game.GetOpponent(Controller.Id)).Hand.Size;
        }
    }
}
