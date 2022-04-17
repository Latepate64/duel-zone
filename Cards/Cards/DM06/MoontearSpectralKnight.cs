using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM06
{
    class MoontearSpectralKnight : Creature
    {
        public MoontearSpectralKnight() : base("Moontear, Spectral Knight", 2, 3500, Race.RainbowPhantom, Civilization.Light)
        {
            AddStaticAbilities(new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect());
        }
    }
}
