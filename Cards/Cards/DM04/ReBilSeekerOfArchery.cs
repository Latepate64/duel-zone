using Common;

namespace Cards.Cards.DM04
{
    class ReBilSeekerOfArchery : Creature
    {
        public ReBilSeekerOfArchery() : base("Re Bil, Seeker of Archery", 7, 6000, Subtype.MechaThunder, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.EachOtherCivilizationCreaturePowerAbility(Civilization.Light, 2000), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
