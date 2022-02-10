using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    public class BlizzardOfSpears : Spell
    {
        public BlizzardOfSpears() : base("Blizzard of Spears", 6, Civilization.Fire)
        {
            // Destroy all creatures that have power 4000 or less.
            Abilities.Add(new SpellAbility(new DestroyAreaOfEffect(new BattleZoneMaxPowerCreatureFilter(4000))));
        }
    }
}
