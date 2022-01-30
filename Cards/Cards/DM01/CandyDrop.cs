using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class CandyDrop : Creature
    {
        public CandyDrop() : base("Candy Drop", 3, Civilization.Water, 1000, Subtype.CyberVirus)
        {
            Abilities.Add(new UnblockableAbility());
        }
    }
}
