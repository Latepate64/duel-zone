using TriggeredAbilities;
using OneShotEffects;

namespace Cards.Cards.DM01
{
    class BlackFeatherShadowOfRage : Engine.Creature
    {
        public BlackFeatherShadowOfRage() : base("Black Feather, Shadow of Rage", 1, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SacrificeEffect()));
        }
    }
}
