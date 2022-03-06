using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class SpasticMissile : Spell
    {
        public SpasticMissile() : base("Spastic Missile", 3, Common.Civilization.Fire)
        {
            // Destroy one of your opponent's creatures that has power 3000 or less.
            AddAbilities(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(3000), 1, 1, true)));
        }
    }
}
