using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM05
{
    class BloodwingMantis : Creature
    {
        public BloodwingMantis() : base("Bloodwing Mantis", 5, 6000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new AttackAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = CardType.Creature }, 2, 2, true)), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
