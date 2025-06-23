using ContinuousEffects;
using Abilities;

namespace Cards.DM05
{
    sealed class GigalingQ : Creature
    {
        public GigalingQ() : base("Gigaling Q", 5, 2000, [Interfaces.Race.Survivor, Interfaces.Race.Chimera], Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureHasSlayerEffect())));
        }
    }
}
