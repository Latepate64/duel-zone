using Cards.StaticAbilities;

namespace Cards.Cards.DM02
{
    class GrayBalloonShadowOfGreed : Creature
    {
        public GrayBalloonShadowOfGreed() : base("Gray Balloon, Shadow of Greed", 3, 3000, Common.Subtype.Ghost, Common.Civilization.Darkness)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
