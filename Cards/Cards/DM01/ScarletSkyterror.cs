using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class ScarletSkyterror : Creature
    {
        public ScarletSkyterror() : base("Scarlet Skyterror", 8, 3000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            // When you put this creature into the battle zone, destroy all creatures that have "blocker."
            Abilities.Add(new PutIntoPlayAbility(new DestroyAreaOfEffect(new BattleZoneBlockerCreatureFilter())));
        }
    }
}
