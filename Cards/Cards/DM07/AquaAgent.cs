using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 6, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            //TODO: Water stealth
            // When this creature would be destroyed, you may return it to your hand instead.
            AddAbilities(new StaticAbility(new DestructionReplacementOptionallyToHandEffect(new Engine.TargetFilter())));
        }
    }
}
