using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class MilieusTheDaystretcher : Creature
    {
        public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Engine.Subtype.Berserker, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Engine.Civilization.Darkness, 2));
        }
    }
}
