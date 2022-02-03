using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class CandyDrop : Creature
    {
        public CandyDrop() : base("Candy Drop", 3, Common.Civilization.Water, 1000, Common.Subtype.CyberVirus)
        {
            Abilities.Add(new UnblockableAbility());
        }
    }
}
