using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class LeapingTornadoHorn : Creature
    {
        public LeapingTornadoHorn() : base("Leaping Tornado Horn", 3, 2000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new StaticAbility(new ContinuousEffects.PowerAttackerMultiplierEffect(1000, new CardFilters.OwnersBattleZoneCreatureExceptFilter())));
        }
    }
}
