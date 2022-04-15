using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class MagmadragonOgristVhal : Creature
    {
        public MagmadragonOgristVhal() : base("Magmadragon Ogrist Vhal", 7, 3000, Engine.Subtype.VolcanoDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new MagmadragonOgristVhalEffect(), new ContinuousEffects.PoweredTripleBreaker());
        }
    }

    class MagmadragonOgristVhalEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public MagmadragonOgristVhalEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MagmadragonOgristVhalEffect();
        }

        public override string ToString()
        {
            return "This creature gets +3000 power for each card in your hand.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return GetController(game).Hand.Cards.Count();
        }
    }
}
