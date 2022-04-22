using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class MagmadragonOgristVhal : Creature
    {
        public MagmadragonOgristVhal() : base("Magmadragon Ogrist Vhal", 7, 3000, Race.VolcanoDragon, Civilization.Fire)
        {
            AddStaticAbilities(new MagmadragonOgristVhalEffect(), new ContinuousEffects.PoweredTripleBreaker());
        }
    }

    class MagmadragonOgristVhalEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public MagmadragonOgristVhalEffect(int power = 3000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MagmadragonOgristVhalEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each card in your hand.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Controller.Hand.Cards.Count();
        }
    }
}
