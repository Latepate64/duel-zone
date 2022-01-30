using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class IllusionaryMerfolk : Creature
    {
        public IllusionaryMerfolk() : base("Illusionary Merfolk", 5, Civilization.Water, 4000, Subtype.GelFish)
        {
            // When you put this creature into the battle zone, if you have a Cyber Lord in the battle zone, draw up to 3 cards.
            Abilities.Add(new IllusionaryMerfolkAbility());
        }
    }
}
