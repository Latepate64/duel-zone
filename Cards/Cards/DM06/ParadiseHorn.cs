using Common;

namespace Cards.Cards.DM06
{
    class ParadiseHorn : Creature
    {
        public ParadiseHorn() : base("Paradise Horn", 4, 3000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
