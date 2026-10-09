using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM02
{
    sealed class GrayBalloonShadowOfGreed : Creature
    {
        public GrayBalloonShadowOfGreed() : base("Gray Balloon, Shadow of Greed", 3, 3000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
