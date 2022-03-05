using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM05
{
    class BloodwingMantis : Creature
    {
        public BloodwingMantis() : base("Bloodwing Mantis", 5, Civilization.Nature, 6000, Subtype.GiantInsect)
        {
            Abilities.Add(new AttackAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = CardType.Creature }, 2, 2, true)));
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
