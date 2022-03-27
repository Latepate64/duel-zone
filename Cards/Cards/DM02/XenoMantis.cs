using Cards.StaticAbilities;

namespace Cards.Cards.DM02
{
    class XenoMantis : Creature
    {
        public XenoMantis() : base("Xeno Mantis", 7, 6000, Common.Subtype.GiantInsect, Common.Civilization.Nature)
        {
            AddAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerAbility(5000), new DoubleBreakerAbility());
        }
    }
}
