using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM07
{
    public class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 6, Common.Civilization.Water, 2000, Common.Subtype.LiquidPeople)
        {
            //TODO: Water stealth
            // When this creature would be destroyed, you may return it to your hand instead.
            Abilities.Add(new AquaAgentAbility());
        }
    }
}
