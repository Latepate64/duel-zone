namespace Cards.Cards.DM07
{
    class Biancus : Creature
    {
        public Biancus() : base("Biancus", 6, 3000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddTapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
