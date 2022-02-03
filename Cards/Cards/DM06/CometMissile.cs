using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    public class CometMissile : Spell
    {
        public CometMissile() : base("Comet Missile", 1, Common.Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy one of your opponent's creatures that has "blocker" and power 6000 or less.
            Abilities.Add(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(6000), 1, 1, true)));
        }
    }
}
