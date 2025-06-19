using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class GigalingQ : Creature
    {
        public GigalingQ() : base("Gigaling Q", 5, 2000, [Engine.Race.Survivor, Engine.Race.Chimera], Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureHasSlayerEffect())));
        }
    }
}
