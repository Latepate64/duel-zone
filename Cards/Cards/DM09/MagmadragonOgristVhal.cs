using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class MagmadragonOgristVhal : Creature
    {
        public MagmadragonOgristVhal() : base("Magmadragon Ogrist Vhal", 7, 3000, Subtype.VolcanoDragon, Civilization.Fire)
        {
            AddStaticAbilities(new MagmadragonOgristVhalEffect(), new ContinuousEffects.PoweredTripleBreaker());
        }
    }

    class MagmadragonOgristVhalEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public MagmadragonOgristVhalEffect() : base(2000, new CardFilters.OwnersHandCardFilter())
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
    }
}
