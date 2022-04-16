using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class BlackFeatherShadowOfRage : Creature
    {
        public BlackFeatherShadowOfRage() : base("Black Feather, Shadow of Rage", 1, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new SacrificeEffect());
        }
    }
}
