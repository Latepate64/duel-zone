namespace Cards.Cards.DM08
{
    class Gigaclaws : TurboRushCreature
    {
        public Gigaclaws() : base("Gigaclaws", 5, 2000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YourOpponentDiscardsHisHandEffect()));
        }
    }
}
