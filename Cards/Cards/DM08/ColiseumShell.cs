using TriggeredAbilities;

namespace Cards.Cards.DM08
{
    class ColiseumShell : Engine.Creature
    {
        public ColiseumShell() : base("Coliseum Shell", 4, 3000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
