using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class DeathSmoke : Spell
    {
        public DeathSmoke() : base("Death Smoke", 4, Civilization.Darkness)
        {
            // Destroy 1 of your opponent's untapped creatures.
            Abilities.Add(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true)));
        }
    }
}
