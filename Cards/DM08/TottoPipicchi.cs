using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM08
{
    sealed class TottoPipicchi : Creature
    {
        public TottoPipicchi() : base("Totto Pipicchi", 3, 1000, Race.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new TottoPipicchiEffect());
        }
    }

    sealed class TottoPipicchiEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public TottoPipicchiEffect() : base()
        {
        }

        public bool Applies(ICreature creature, IGame game)
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
