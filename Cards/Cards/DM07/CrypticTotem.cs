using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class CrypticTotem : Creature
    {
        public CrypticTotem() : base("Cryptic Totem", 6, 6000, Race.MysteryTotem, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new CrypticTotemEffect());
        }
    }

    class CrypticTotemEffect : ContinuousEffect, ICannotUseShieldTriggerEffect
    {
        public CrypticTotemEffect()
        {
        }

        public CrypticTotemEffect(CrypticTotemEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard shield, IGame game)
        {
            return Source.Tapped && Applier.Opponent.Id == shield.Id;
        }

        public override IContinuousEffect Copy()
        {
            return new CrypticTotemEffect(this);
        }

        public override string ToString()
        {
            return "While this creature is tapped, your opponent can't use the \"shield trigger\" ability of his shields.";
        }
    }
}
