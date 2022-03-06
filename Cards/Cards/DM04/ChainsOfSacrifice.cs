using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class ChainsOfSacrifice : Spell
    {
        public ChainsOfSacrifice() : base("Chains of Sacrifice", 8, Civilization.Darkness)
        {
            // Destroy up to 2 of your opponent's creatures.
            // Destroy one of your creatures.
            AddAbilities(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 0, 2, true)), new SpellAbility(new SacrificeEffect()));
        }
    }
}
