using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM07
{
    public class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 6, Civilization.Water, 2000, Subtype.LiquidPeople)
        {
            //TODO: Water stealth
            // When this creature would be destroyed, you may return it to your hand instead.
            Abilities.Add(new AquaAgentAbility());
        }
    }
}
