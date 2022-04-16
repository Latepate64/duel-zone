using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM06
{
    class ChoyaTheUnheeding : Creature
    {
        public ChoyaTheUnheeding() : base("Choya, the Unheeding", 2, 1000, Race.Human, Civilization.Fire)
        {
            AddPowerAttackerAbility(1000);
            AddStaticAbilities(new SkipBattleAfterBecomesBlockedEffect());
        }
    }
}
