using Common;

namespace Cards.Cards.DM12
{
    class FranticChieftain : Creature
    {
        public FranticChieftain() : base("Frantic Chieftain", 2, 2000, Subtype.Merfolk, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.BounceEffect(1, 1, new CardFilters.OwnersBattleZoneCreatureFilter { ManaCost = new Engine.ManaCostFilter(Engine.CompareMode.Max, 4)})));
        }
    }
}
