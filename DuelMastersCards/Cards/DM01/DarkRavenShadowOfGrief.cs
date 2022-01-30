using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class DarkRavenShadowOfGrief : Creature
    {
        public DarkRavenShadowOfGrief() : base("Dark Raven, Shadow of Grief", 4, Civilization.Darkness, 1000, Subtype.Ghost)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
