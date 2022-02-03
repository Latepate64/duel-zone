using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class FaerieChild : Creature
    {
        public FaerieChild() : base("Faerie Child", 4, Common.Civilization.Water, 2000, Common.Subtype.CyberVirus)
        {
            Abilities.Add(new UnblockableAbility());
        }
    }
}
