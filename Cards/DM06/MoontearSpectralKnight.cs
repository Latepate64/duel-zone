using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06
{
    sealed class MoontearSpectralKnight : Creature
    {
        public MoontearSpectralKnight() : base("Moontear, Spectral Knight", 2, 3500, Race.RainbowPhantom, Civilization.Light)
        {
            AddStaticAbilities(new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect());
        }
    }
}
