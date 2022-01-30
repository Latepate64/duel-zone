using Cards.CardFilters;
using Cards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class SonicWing : Spell
    {
        public SonicWing() : base("Sonic Wing", 3, Civilization.Light)
        {
            // Choose one of your creatures in the battle zone. It can't be blocked this turn.
            Abilities.Add(new SpellAbility(new CreateContinuousEffectChoiceEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true, new UnblockableEffect(null, new DuelMastersModels.Durations.UntilTheEndOfTheTurn(), new AnyFilter()))));
        }
    }
}
