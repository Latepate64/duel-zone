using Cards.StaticAbilities;

namespace Cards.Cards.DM02
{
    class AquaShooter : Creature
    {
        public AquaShooter() : base("Aqua Shooter", 4, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
