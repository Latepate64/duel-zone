using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class CosmicWing : Spell
    {
        public CosmicWing() : base("Cosmic Wing", 3, Common.Civilization.Light)
        {
            // Choose one of your creatures in the battle zone. It can't be blocked this turn.
            AddSpellAbilities(new CreateContinuousEffectChoiceEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true, new UnblockableEffect(null, new Engine.Durations.UntilTheEndOfTheTurn(), new BattleZoneCreatureFilter())));
        }
    }
}
