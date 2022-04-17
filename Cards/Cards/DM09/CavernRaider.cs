namespace Cards.Cards.DM09
{
    class CavernRaider : Creature
    {
        public CavernRaider() : base("Cavern Raider", 3, 2000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
