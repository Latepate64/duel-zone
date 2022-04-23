using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class MilieusTheDaystretcher : Creature
    {
        public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new MilieusEffect());
        }
    }

    class MilieusEffect : EachCivilizationCardCostsMoreEffect
    {
        public MilieusEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public MilieusEffect(Engine.Civilization civilization = Engine.Civilization.Darkness) : base(2, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MilieusEffect(this);
        }
    }
}
