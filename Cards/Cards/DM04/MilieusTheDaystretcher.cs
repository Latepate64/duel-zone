using Common;

namespace Cards.Cards.DM04
{
    class MilieusTheDaystretcher : Creature
    {
        public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Subtype.Berserker, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new StaticAbilities.EachCivilizationCardCostsMoreAbility(Civilization.Darkness, 2));
        }
    }
}
