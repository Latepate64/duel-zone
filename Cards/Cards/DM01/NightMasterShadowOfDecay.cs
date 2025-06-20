using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class NightMasterShadowOfDecay : Engine.Creature
    {
        public NightMasterShadowOfDecay() : base("Night Master, Shadow of Decay", 6, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
