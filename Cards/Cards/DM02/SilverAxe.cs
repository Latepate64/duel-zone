using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class SilverAxe : Engine.Creature
    {
        public SilverAxe() : base("Silver Axe", 3, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
