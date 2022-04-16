using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class ReBilSeekerOfArchery : Creature
    {
        public ReBilSeekerOfArchery() : base("Re Bil, Seeker of Archery", 7, 6000, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new EachOtherCivilizationCreaturePowerEffect(Engine.Civilization.Light, 2000));
            AddDoubleBreakerAbility();
        }
    }
}
