using TriggeredAbilities;

namespace Cards.DM10
{
    sealed class SabermaskScarab : Creature
    {
        public SabermaskScarab() : base("Sabermask Scarab", 4, 4000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}
