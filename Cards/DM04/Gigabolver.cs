using ContinuousEffects;

namespace Cards.DM04
{
    sealed class Gigabolver : Engine.Creature
    {
        public Gigabolver() : base("Gigabolver", 4, 3000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(Interfaces.Civilization.Light));
        }
    }
}
