using Cards.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class XenoMantis : Creature
    {
        public XenoMantis() : base("Xeno Mantis", 7, 6000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(5000));
            AddDoubleBreakerAbility();
        }
    }
}
