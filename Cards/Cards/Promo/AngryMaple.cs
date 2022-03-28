using Common;

namespace Cards.Cards.Promo
{
    class AngryMaple : Creature
    {
        public AngryMaple() : base("Angry Maple", 3, 1000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddPowerAttackerAbility(4000);
        }
    }
}
