using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class FuReilSeekerOfStorms : Creature
    {
        public FuReilSeekerOfStorms() : base("Fu Reil, Seeker of Storms", 6, 5000, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(Engine.Civilization.Darkness));
        }
    }
}
