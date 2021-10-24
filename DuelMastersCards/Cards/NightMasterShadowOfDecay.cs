using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class NightMasterShadowOfDecay : Creature
    {
        public NightMasterShadowOfDecay() : base("Night Master, Shadow of Decay", 6, Civilization.Darkness, 3000, Subtype.Ghost)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
