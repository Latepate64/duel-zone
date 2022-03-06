using Cards.StaticAbilities;

namespace Cards.Cards.DM02
{
    class AquaShooter : Creature
    {
        public AquaShooter() : base("Aqua Shooter", 4, Common.Civilization.Water, 2000, Common.Subtype.LiquidPeople)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
