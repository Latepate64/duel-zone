namespace Cards.Cards.DM05
{
    class ObsidianScarab : Creature
    {
        public ObsidianScarab() : base("Obsidian Scarab", 6, 5000, Engine.Subtype.GiantInsect, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddDoubleBreakerAbility();
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(Name));
        }
    }
}
