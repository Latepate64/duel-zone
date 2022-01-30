using Cards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace Cards.Cards.DM01
{
    public class Teleportation : Spell
    {
        public Teleportation() : base("Teleportation", 5, Civilization.Water)
        {
            // Choose up to 2 creatures in the battle zone and return them to their owners' hands.
            Abilities.Add(new SpellAbility(new BounceEffect(0, 2, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}
