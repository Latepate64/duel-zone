using Cards.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class FerrosaturnSpectralKnight : Engine.Creature
    {
        public FerrosaturnSpectralKnight() : base("Ferrosaturn, Spectral Knight", 1, 2000, Engine.Race.RainbowPhantom, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
