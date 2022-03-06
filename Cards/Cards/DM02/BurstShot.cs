using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 6, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy all creatures that have power 2000 or less.
            Abilities.Add(new SpellAbility(new DestroyAreaOfEffect(new BattleZoneMaxPowerCreatureFilter(2000))));
        }
    }
}
