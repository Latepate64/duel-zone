using ContinuousEffects;
using Engine;

namespace Cards.DM06
{
    class MoontearSpectralKnight : Creature
    {
        public MoontearSpectralKnight() : base("Moontear, Spectral Knight", 2, 3500, Race.RainbowPhantom, Civilization.Light)
        {
            AddStaticAbilities(new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect());
        }
    }
}
