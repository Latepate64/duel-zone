using ContinuousEffects;

namespace Cards.DM09
{
    sealed class AcidRefluxTheFleshboiler : Engine.Creature
    {
        public AcidRefluxTheFleshboiler() : base("Acid Reflux, the Fleshboiler", 5, 3000, Interfaces.Race.DevilMask, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
