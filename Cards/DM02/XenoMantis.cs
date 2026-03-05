using ContinuousEffects;

namespace Cards.DM02
{
    sealed class XenoMantis : Creature
    {
        public XenoMantis() : base("Xeno Mantis", 7, 6000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(5000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
