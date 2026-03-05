using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class Vikorakys : TurboRushCreature
    {
        public Vikorakys() : base("Vikorakys", 3, 1000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddTurboRushAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.SearchCardNoRevealEffect()));
        }
    }
}
