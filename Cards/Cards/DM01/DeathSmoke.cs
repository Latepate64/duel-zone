using Cards.CardFilters;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class DeathSmoke : Spell
    {
        public DeathSmoke() : base("Death Smoke", 4, Common.Civilization.Darkness)
        {
            // Destroy 1 of your opponent's untapped creatures.
            AddSpellAbilities(new DestroyEffect(new OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true));
        }
    }
}
