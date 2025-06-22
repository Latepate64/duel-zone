using ContinuousEffects;

namespace Cards.DM12
{
    sealed class HypersprintWariorUzesol : Engine.Creature
    {
        public HypersprintWariorUzesol() : base("Hypersprint Warior Uzesol", 4, 1000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
