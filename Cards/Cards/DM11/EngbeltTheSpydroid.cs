namespace Cards.Cards.DM11
{
    class EngbeltTheSpydroid : Creature
    {
        public EngbeltTheSpydroid() : base("Engbelt, the Spydroid", 4, 5500, Engine.Subtype.Soltrooper, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
