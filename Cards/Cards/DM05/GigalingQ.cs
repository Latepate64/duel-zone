using Common;

namespace Cards.Cards.DM05
{
    class GigalingQ : Creature
    {
        public GigalingQ() : base("Gigaling Q", 5, 2000, Engine.Subtype.Survivor, Engine.Subtype.Chimera, Civilization.Darkness)
        {
            AddSurvivorAbility(new ContinuousEffects.ThisCreatureHasSlayerEffect());
        }
    }
}
