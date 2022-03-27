using Common;

namespace Cards.Cards.DM05
{
    class ObsidianScarab : Creature
    {
        public ObsidianScarab() : base("Obsidian Scarab", 6, 5000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(3000), new StaticAbilities.DoubleBreakerAbility(), new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(Name)));
        }
    }
}
