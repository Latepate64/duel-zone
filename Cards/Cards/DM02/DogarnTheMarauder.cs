using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class DogarnTheMarauder : Creature
    {
        public DogarnTheMarauder() : base("Dogarn, the Marauder", 3, 2000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new StaticAbility(new ContinuousEffects.PowerAttackerMultiplierEffect(2000, new CardFilters.OwnersBattleZoneTappedCreatureExceptFilter())));
        }
    }
}
