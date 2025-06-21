using ContinuousEffects;

namespace Cards.DM01
{
    class NightMasterShadowOfDecay : Engine.Creature
    {
        public NightMasterShadowOfDecay() : base("Night Master, Shadow of Decay", 6, 3000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
