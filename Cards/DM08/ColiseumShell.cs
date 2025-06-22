using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class ColiseumShell : Engine.Creature
    {
        public ColiseumShell() : base("Coliseum Shell", 4, 3000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
