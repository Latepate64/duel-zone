using ContinuousEffects;

namespace Cards.DM06
{
    class Gigagriff : Engine.Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
