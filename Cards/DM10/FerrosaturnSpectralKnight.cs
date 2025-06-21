using ContinuousEffects;

namespace Cards.DM10
{
    class FerrosaturnSpectralKnight : Engine.Creature
    {
        public FerrosaturnSpectralKnight() : base("Ferrosaturn, Spectral Knight", 1, 2000, Interfaces.Race.RainbowPhantom, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
