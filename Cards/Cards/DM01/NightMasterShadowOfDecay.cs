using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class NightMasterShadowOfDecay : Creature
    {
        public NightMasterShadowOfDecay() : base("Night Master, Shadow of Decay", 6, Common.Civilization.Darkness, 3000, Common.Subtype.Ghost)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
