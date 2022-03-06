using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class Magmarex : Creature
    {
        public Magmarex() : base("Magmarex", 5, Civilization.Fire, 3000, Subtype.RockBeast)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, destroy all creatures that have power 1000.
            Abilities.Add(new PutIntoPlayAbility(new DestroyAreaOfEffect(new BattleZoneExactPowerCreatureFilter(1000))));
        }
    }
}
