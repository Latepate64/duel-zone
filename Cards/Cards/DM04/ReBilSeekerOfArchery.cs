using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class ReBilSeekerOfArchery : Creature
    {
        public ReBilSeekerOfArchery() : base("Re Bil, Seeker of Archery", 7, 6000, Engine.Subtype.MechaThunder, Civilization.Light)
        {
            AddStaticAbilities(new EachOtherCivilizationCreaturePowerEffect(Civilization.Light, 2000));
            AddDoubleBreakerAbility();
        }
    }
}
