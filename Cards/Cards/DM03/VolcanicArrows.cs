using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class VolcanicArrows : Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Common.Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy a creature that has power 6000 or less.
            // Choose one of your shields and put it into your graveyard.
            AddAbilities(new SpellAbility(new DestroyEffect(new BattleZoneChoosableMaxPowerCreatureFilter(6000), 1, 1, true)), new SpellAbility(new SelfShieldBurnEffect()));
        }
    }
}
