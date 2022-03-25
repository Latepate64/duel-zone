using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class CandyDrop : Creature
    {
        public CandyDrop() : base("Candy Drop", 3, 1000, Common.Subtype.CyberVirus, Common.Civilization.Water)
        {
            AddAbilities(new ThisCreatureCannotBeBlockedAbility());
        }
    }
}
