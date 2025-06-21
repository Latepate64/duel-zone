using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    class BlackFeatherShadowOfRage : Engine.Creature
    {
        public BlackFeatherShadowOfRage() : base("Black Feather, Shadow of Rage", 1, 3000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SacrificeEffect()));
        }
    }
}
