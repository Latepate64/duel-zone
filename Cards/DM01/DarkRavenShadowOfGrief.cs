using Abilities.Static;

namespace Cards.DM01
{
    sealed class DarkRavenShadowOfGrief : Creature
    {
        public DarkRavenShadowOfGrief() : base("Dark Raven, Shadow of Grief", 4, 1000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
