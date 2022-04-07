using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class TottoPipicchi : Creature
    {
        public TottoPipicchi() : base("Totto Pipicchi", 3, 1000, Subtype.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new TottoPipicchiEffect());
        }
    }

    class TottoPipicchiEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public TottoPipicchiEffect() : base()
        {
        }

        public bool Applies(Engine.ICard creature, IGame game)
        {
            return creature.IsDragon;
        }

        public override IContinuousEffect Copy()
        {
            return new TottoPipicchiEffect();
        }

        public override string ToString()
        {
            return "Each creature in the battle zone that has Dragon in its race has \"speed attacker.\"";
        }
    }
}
