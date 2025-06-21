using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    class GalliaZohlIronGuardianQ : Engine.Creature
    {
        public GalliaZohlIronGuardianQ() : base("Gallia Zohl, Iron Guardian Q", 5, 2000, [Engine.Race.Survivor, Engine.Race.Guardian], Engine.Civilization.Light)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureHasBlockerEffect())));
        }
    }
}
