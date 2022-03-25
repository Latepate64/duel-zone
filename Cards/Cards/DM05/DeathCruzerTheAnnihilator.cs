using Common;

namespace Cards.Cards.DM05
{
    class DeathCruzerTheAnnihilator : Creature
    {
        public DeathCruzerTheAnnihilator() : base("Death Cruzer, the Annihilator", 7, 13000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.DestroyAreaOfEffect(new CardFilters.OwnersOtherBattleZoneCreatureFilter())), new StaticAbilities.TripleBreakerAbility());
        }
    }
}
