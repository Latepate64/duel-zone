namespace Cards.Cards.DM01
{
    class LaUraGigaSkyGuardian : Creature
    {
        public LaUraGigaSkyGuardian() : base("La Ura Giga, Sky Guardian", 1, 2000, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
