using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class BlackFeatherShadowOfRage : Creature
    {
        public BlackFeatherShadowOfRage() : base("Black Feather, Shadow of Rage", 1, 3000, Common.Subtype.Ghost, Common.Civilization.Darkness)
        {
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SacrificeEffect()));
        }
    }
}
