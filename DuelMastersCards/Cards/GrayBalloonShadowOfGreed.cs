using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class GrayBalloonShadowOfGreed : Creature
    {
        public GrayBalloonShadowOfGreed() : base("Gray Balloon, Shadow of Greed", 3, Civilization.Darkness, 3000, Subtype.Ghost)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
