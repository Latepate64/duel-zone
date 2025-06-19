using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM02
{
    class XenoMantis : Engine.Creature
    {
        public XenoMantis() : base("Xeno Mantis", 7, 6000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(5000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
