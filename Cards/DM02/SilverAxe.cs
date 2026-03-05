using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class SilverAxe : Creature
    {
        public SilverAxe() : base("Silver Axe", 3, 1000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
