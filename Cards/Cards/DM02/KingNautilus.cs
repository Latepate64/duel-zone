using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class KingNautilus : Creature
    {
        public KingNautilus() : base("King Nautilus", 8, 6000, Subtype.Leviathan, Civilization.Water)
        {
            AddStaticAbilities(new KingNautilusEffect());
            AddDoubleBreakerAbility();
        }
    }

    class KingNautilusEffect : ContinuousEffect, IUnblockableEffect
    {
        public KingNautilusEffect() : base()
        {
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard blocker, IGame game)
        {
            return attacker.HasSubtype(Subtype.LiquidPeople);
        }

        public override IContinuousEffect Copy()
        {
            return new KingNautilusEffect();
        }

        public override string ToString()
        {
            return "Liquid People can't be blocked.";
        }
    }
}
