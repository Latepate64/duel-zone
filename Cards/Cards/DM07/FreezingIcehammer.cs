using Common;

namespace Cards.Cards.DM07
{
    class FreezingIcehammer : Spell
    {
        public FreezingIcehammer() : base("Freezing Icehammer", 3, Civilization.Nature)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.ManaFeedEffect(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(Civilization.Water, Civilization.Darkness), 1, 1, true)));
        }
    }
}
