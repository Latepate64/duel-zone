using Common;

namespace Cards.Cards.DM05
{
    class BolgashDragon : Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, 4000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddPowerAttackerAbility(8000);
            AddTripleBreakerAbility();
        }
    }
}
