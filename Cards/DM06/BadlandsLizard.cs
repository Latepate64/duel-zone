using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06
{
    sealed class BadlandsLizard : Creature
    {
        public BadlandsLizard() : base("Badlands Lizard", 5, 3000, Race.DuneGecko, Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddStaticAbilities(new SkipBattleAfterBecomesBlockedEffect());
        }
    }
}
