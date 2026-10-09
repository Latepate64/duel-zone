using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM09
{
    sealed class AcidRefluxTheFleshboiler : Creature
    {
        public AcidRefluxTheFleshboiler() : base("Acid Reflux, the Fleshboiler", 5, 3000, Interfaces.Race.DevilMask, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddAbilities(new SlayerAbility());
        }
    }
}
