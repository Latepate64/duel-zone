using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06
{
    sealed class ChoyaTheUnheeding : Creature
    {
        public ChoyaTheUnheeding() : base("Choya, the Unheeding", 2, 1000, Race.Human, Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(1000));
            AddStaticAbilities(new SkipBattleAfterBecomesBlockedEffect());
        }
    }
}
