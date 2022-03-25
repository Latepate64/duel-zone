using Common;

namespace Cards.Cards.DM04
{
    class NiofaHornedProtector : EvolutionCreature
    {
        public NiofaHornedProtector() : base("Niofa, Horned Protector", 6, 9000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TutoringEffect(new CardFilters.OwnersDeckCivilizationCreatureFilter(Civilization.Nature), true)), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
