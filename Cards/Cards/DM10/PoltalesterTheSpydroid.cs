namespace Cards.Cards.DM10
{
    class PoltalesterTheSpydroid : Creature
    {
        public PoltalesterTheSpydroid() : base("Poltalester, the Spydroid", 5, 2000, Engine.Race.Soltrooper, Engine.Civilization.Light)
        {
            AddShieldTrigger();
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
