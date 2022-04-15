namespace Cards.Cards.DM01
{
    class PoisonousDahlia : Creature
    {
        public PoisonousDahlia() : base("Poisonous Dahlia", 4, 5000, Engine.Subtype.TreeFolk, Common.Civilization.Nature)
        {
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
