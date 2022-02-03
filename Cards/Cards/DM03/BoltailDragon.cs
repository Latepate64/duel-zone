using Common;

namespace Cards.Cards.DM03
{
    class BoltailDragon : Creature
    {
        public BoltailDragon() : base("Boltail Dragon", 7, Common.Civilization.Fire, 9000, Common.Subtype.ArmoredDragon)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
