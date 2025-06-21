using TriggeredAbilities;

namespace Cards.DM08
{
    class Vikorakys : TurboRushCreature
    {
        public Vikorakys() : base("Vikorakys", 3, 1000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddTurboRushAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.SearchCardNoRevealEffect()));
        }
    }
}
