using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 1, Civilization.Water, 2000, Subtype.LiquidPeople) //TODO: Mana cost to 6
        {
            //TODO: Water stealth
            Abilities.Add(new AquaAgentAbility());
        }
    }
}
