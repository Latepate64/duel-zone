using Cards.StaticAbilities;

namespace Cards.Cards.DM02
{
    class GrayBalloonShadowOfGreed : Creature
    {
        public GrayBalloonShadowOfGreed() : base("Gray Balloon, Shadow of Greed", 3, Common.Civilization.Darkness, 3000, Common.Subtype.Ghost)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
