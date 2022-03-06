using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class TerrorPit : Spell
    {
        public TerrorPit() : base("Terror Pit", 6, Common.Civilization.Darkness)
        {
            ShieldTrigger = true;
            // Destroy 1 of your opponent's creatures.
            AddAbilities(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }
}
