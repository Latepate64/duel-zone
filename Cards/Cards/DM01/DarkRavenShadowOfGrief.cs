using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DarkRavenShadowOfGrief : Creature
    {
        public DarkRavenShadowOfGrief() : base("Dark Raven, Shadow of Grief", 4, Common.Civilization.Darkness, 1000, Common.Subtype.Ghost)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
