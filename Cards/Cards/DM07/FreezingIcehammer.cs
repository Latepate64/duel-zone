using Common;

namespace Cards.Cards.DM07
{
    class FreezingIcehammer : Spell
    {
        public FreezingIcehammer() : base("Freezing Icehammer", 3, Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.ManaFeedEffect(new CardFilters.OpponentsBattleZoneChoosableCivilizationCreatureFilter(Civilization.Water, Civilization.Darkness), 1, 1, true));
        }
    }
}
