namespace Cards.Cards.DM08
{
    class Vikorakys : TurboRushCreature
    {
        public Vikorakys() : base("Vikorakys", 3, 1000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SearchCardNoRevealEffect()));
        }
    }
}
