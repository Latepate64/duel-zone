using Common;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class BroodShell : Creature
    {
        public BroodShell() : base("Brood Shell", 4, Civilization.Nature, 3000, Subtype.ColonyBeetle)
        {
            Abilities.Add(new TapAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = CardType.Creature }, 1, 1, true)));
        }
    }
}
