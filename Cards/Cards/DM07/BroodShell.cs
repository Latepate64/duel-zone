using Common;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class BroodShell : Creature
    {
        public BroodShell() : base("Brood Shell", 4, 3000, Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.SelfManaRecoveryEffect(1, 1, true, new CardFilters.OwnersManaZoneCreatureFilter())));
        }
    }
}
