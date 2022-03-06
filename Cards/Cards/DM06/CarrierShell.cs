using Common;

namespace Cards.Cards.DM06
{
    class CarrierShell : Creature
    {
        public CarrierShell() : base("Carrier Shell", 3, 2000, Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(3000));
        }
    }
}
