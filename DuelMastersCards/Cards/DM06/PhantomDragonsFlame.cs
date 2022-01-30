using Cards.CardFilters;
using Cards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace Cards.Cards.DM06
{
    public class PhantomDragonsFlame : Spell
    {
        public PhantomDragonsFlame() : base("Phantom Dragon's Flame", 3, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy one of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 1, 1, true)));
        }
    }
}
