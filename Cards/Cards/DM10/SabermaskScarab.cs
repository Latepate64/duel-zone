using Abilities.Triggered;

namespace Cards.Cards.DM10
{
    class SabermaskScarab : Engine.Creature
    {
        public SabermaskScarab() : base("Sabermask Scarab", 4, 4000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}
