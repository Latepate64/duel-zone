using Common;

namespace Cards.StaticAbilities
{
    class StealthAbility : Engine.Abilities.StaticAbility
    {
        public StealthAbility(Civilization civilization) : base(new ContinuousEffects.StealthEffect(civilization))
        {
        }
    }
}