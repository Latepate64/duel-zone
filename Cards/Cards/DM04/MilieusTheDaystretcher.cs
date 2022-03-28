using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class MilieusTheDaystretcher : Creature
    {
        public MilieusTheDaystretcher() : base("Milieus, the Daystretcher", 5, 2500, Subtype.Berserker, Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Civilization.Darkness, 2));
        }
    }
}
