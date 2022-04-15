using Common;

namespace Cards.Cards.DM10
{
    class SabermaskScarab : Creature
    {
        public SabermaskScarab() : base("Sabermask Scarab", 4, 4000, Engine.Subtype.GiantInsect, Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
