using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    class GigalingQ : Engine.Creature
    {
        public GigalingQ() : base("Gigaling Q", 5, 2000, [Interfaces.Race.Survivor, Interfaces.Race.Chimera], Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureHasSlayerEffect())));
        }
    }
}
