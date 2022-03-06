using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class VampireSilphy : Creature
    {
        public VampireSilphy() : base("Vampire Silphy", 8, Civilization.Darkness, 4000, Subtype.DarkLord)
        {
            // When you put this creature into the battle zone, destroy all creatures that have power 3000 or less.
            Abilities.Add(new PutIntoPlayAbility(new DestroyAreaOfEffect(new BattleZoneMaxPowerCreatureFilter(3000))));
        }
    }
}
