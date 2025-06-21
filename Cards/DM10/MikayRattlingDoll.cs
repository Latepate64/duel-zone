using ContinuousEffects;

namespace Cards.DM10
{
    class MikayRattlingDoll : Engine.Creature
    {
        public MikayRattlingDoll() : base("Mikay, Rattling Doll", 2, 2000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
