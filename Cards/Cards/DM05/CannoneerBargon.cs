namespace Cards.Cards.DM05
{
    class CannoneerBargon : Creature
    {
        public CannoneerBargon() : base("Cannoneer Bargon", 4, 4000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
