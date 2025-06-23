using ContinuousEffects;

namespace Cards.DM06
{
    sealed class Gigagriff : Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
