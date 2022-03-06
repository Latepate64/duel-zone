using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM05
{
    class BloodwingMantis : Creature
    {
        public BloodwingMantis() : base("Bloodwing Mantis", 5, 6000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new AttackAbility(new OneShotEffects.SelfManaRecoveryEffect(2, 2, true, CardType.Creature)), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
