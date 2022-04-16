namespace Cards.Cards.DM06
{
    class TrenchScarab : Creature
    {
        public TrenchScarab() : base("Trench Scarab", 3, 4000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddThisCreatureCannotAttackPlayersAbility();
            AddPowerAttackerAbility(4000);
        }
    }
}
