using Cards.CardFilters;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class CrimsonHammer : Spell
    {
        public CrimsonHammer() : base("Crimson Hammer", 2, Common.Civilization.Fire)
        {
            // Destroy 1 of your opponent's creatures that has power 2000 or less.
            AddSpellAbilities(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 1, 1, true));
        }
    }
}
