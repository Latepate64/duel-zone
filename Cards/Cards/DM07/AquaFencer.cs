using Common;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class AquaFencer : Creature
    {
        public AquaFencer() : base("Aqua Fencer", 7, Civilization.Water, 3000, Subtype.LiquidPeople)
        {
            Abilities.Add(new TapAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OpponentsManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
