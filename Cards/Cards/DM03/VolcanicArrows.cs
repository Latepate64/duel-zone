using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    public class VolcanicArrows : Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Common.Civilization.Fire)
        {
            ShieldTrigger = true;

            // Destroy a creature that has power 6000 or less.
            Abilities.Add(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(6000), 1, 1, true)));

            // Choose one of your shields and put it into your graveyard.
            Abilities.Add(new SpellAbility(new SelfShieldBurnEffect()));
        }
    }
}
