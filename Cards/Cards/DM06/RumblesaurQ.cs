using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class RumblesaurQ : Engine.Creature
    {
        public RumblesaurQ() : base("Rumblesaur Q", 6, 3000, [Engine.Race.Survivor, Engine.Race.RockBeast], Engine.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureHasSpeedAttackerEffect())));
        }
    }
}
