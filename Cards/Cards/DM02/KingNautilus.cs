using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class KingNautilus : Creature
    {
        public KingNautilus() : base("King Nautilus", 8, 6000, Engine.Subtype.Leviathan, Engine.Civilization.Water)
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

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return attacker.HasSubtype(Engine.Subtype.LiquidPeople);
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
