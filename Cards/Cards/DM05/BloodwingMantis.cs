using Cards.TriggeredAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class BloodwingMantis : Creature
    {
        public BloodwingMantis() : base("Bloodwing Mantis", 5, 6000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new WheneverThisCreatureAttacksAbility(new BloodwingMantisEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class BloodwingMantisEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public BloodwingMantisEffect() : base(2, 2, true, new CardFilters.OwnersManaZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BloodwingMantisEffect();
        }

        public override string ToString()
        {
            return "Return 2 creatures from your mana zone to your hand.";
        }
    }
}
