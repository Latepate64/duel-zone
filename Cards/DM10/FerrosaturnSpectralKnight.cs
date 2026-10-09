using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM10
{
    sealed class FerrosaturnSpectralKnight : Creature
    {
        public FerrosaturnSpectralKnight() : base("Ferrosaturn, Spectral Knight", 1, 2000, Interfaces.Race.RainbowPhantom, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
