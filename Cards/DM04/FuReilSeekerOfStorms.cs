using ContinuousEffects;

namespace Cards.DM04
{
    sealed class FuReilSeekerOfStorms : Engine.Creature
    {
        public FuReilSeekerOfStorms() : base("Fu Reil, Seeker of Storms", 6, 5000, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(Interfaces.Civilization.Darkness));
        }
    }
}
