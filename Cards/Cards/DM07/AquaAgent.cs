﻿using Cards.ContinuousEffects;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 6, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            //TODO: Water stealth
            AddAbilities(new AquaAgentAbility());
        }
    }

    class AquaAgentAbility : StaticAbility
    {
        public AquaAgentAbility() : base(new AquaAgentEffect())
        {
        }
    }

    class AquaAgentEffect : DestructionReplacementOptionallyToHandEffect
    {
        public AquaAgentEffect() : base(new Engine.TargetFilter()) { }

        public override IContinuousEffect Copy()
        {
            return new AquaAgentEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, you may return it to your hand instead.";
        }
    }
}
