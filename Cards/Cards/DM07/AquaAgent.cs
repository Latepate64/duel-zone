using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 6, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            //TODO: Water stealth
            AddAbilities(new DestructionReplacementOptionallyToHandAbility());
        }
    }

    class DestructionReplacementOptionallyToHandAbility : StaticAbility
    {
        public DestructionReplacementOptionallyToHandAbility() : base(new DestructionReplacementOptionallyToHandEffect(new Engine.TargetFilter()))
        {
        }
    }
}
