using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class IllusionaryMerfolk : Creature
    {
        public IllusionaryMerfolk() : base("Illusionary Merfolk", 5, Common.Civilization.Water, 4000, Common.Subtype.GelFish)
        {
            // When you put this creature into the battle zone, if you have a Cyber Lord in the battle zone, draw up to 3 cards.
            Abilities.Add(new IllusionaryMerfolkAbility());
        }
    }
}
