namespace Cards.Cards.DM10
{
    public class MessaBahnaExpanseGuardian : Creature
    {
        public MessaBahnaExpanseGuardian() : base("Messa Bahna, Expanse Guardian", 3, 5000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureBlocksIfAble();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
