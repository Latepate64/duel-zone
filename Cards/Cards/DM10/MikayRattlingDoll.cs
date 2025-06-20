using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM10
{
    class MikayRattlingDoll : Engine.Creature
    {
        public MikayRattlingDoll() : base("Mikay, Rattling Doll", 2, 2000, Engine.Race.DeathPuppet, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
