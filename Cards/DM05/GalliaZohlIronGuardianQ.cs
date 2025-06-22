using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    sealed class GalliaZohlIronGuardianQ : Engine.Creature
    {
        public GalliaZohlIronGuardianQ() : base("Gallia Zohl, Iron Guardian Q", 5, 2000, [Interfaces.Race.Survivor, Interfaces.Race.Guardian], Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureHasBlockerEffect())));
        }
    }
}
