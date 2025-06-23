using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM06
{
    sealed class RumblesaurQ : Creature
    {
        public RumblesaurQ() : base("Rumblesaur Q", 6, 3000, [Interfaces.Race.Survivor, Interfaces.Race.RockBeast], Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureHasSpeedAttackerEffect())));
        }
    }
}
