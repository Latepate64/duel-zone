using Common;

namespace Cards.Cards.DM05
{
    class LaByleSeekerOfTheWinds : Creature
    {
        public LaByleSeekerOfTheWinds() : base("La Byle, Seeker of the Winds", 7, 5000, Subtype.MechaThunder, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.BlockAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
        }
    }
}
