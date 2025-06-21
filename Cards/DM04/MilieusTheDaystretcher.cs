using ContinuousEffects;
using Interfaces.ContinuousEffects;

namespace Cards.DM04
{
    class MilieusTheDaystretcher : Engine.Creature
    {
        public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Interfaces.Race.Berserker, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new MilieusEffect());
        }
    }

    class MilieusEffect : EachCivilizationCardCostsMoreEffect
    {
        public MilieusEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public MilieusEffect(Interfaces.Civilization civilization = Interfaces.Civilization.Darkness) : base(2, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MilieusEffect(this);
        }
    }
}
