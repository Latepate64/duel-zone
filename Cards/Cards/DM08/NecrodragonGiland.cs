namespace Cards.Cards.DM08
{
    class NecrodragonGiland : Creature
    {
        public NecrodragonGiland() : base("Necrodragon Giland", 4, 6000, Engine.Race.ZombieDragon, Engine.Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
