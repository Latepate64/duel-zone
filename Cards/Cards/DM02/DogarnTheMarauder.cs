using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class DogarnTheMarauder : Creature
    {
        public DogarnTheMarauder() : base("Dogarn, the Marauder", 3, 2000, Subtype.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new DogarnTheMarauderEffect());
        }
    }

    class DogarnTheMarauderEffect : ContinuousEffects.PowerAttackerMultiplierEffect
    {
        public DogarnTheMarauderEffect() : base(2000, new CardFilters.OwnersBattleZoneTappedCreatureExceptFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new DogarnTheMarauderEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +2000 power for each other tapped creature you have in the battle zone.";
        }
    }
}
