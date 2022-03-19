using Common;

namespace Cards.Cards.DM04
{
    class BallomMasterOfDeath : EvolutionCreature
    {
        public BallomMasterOfDeath() : base("Ballom, Master of Death", 8, 12000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.DestroyAreaOfEffect(new CardFilters.BattleZoneNonCivilizationCreatureFilter(Civilization.Darkness))), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
