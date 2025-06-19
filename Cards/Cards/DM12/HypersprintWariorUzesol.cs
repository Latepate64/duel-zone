using Cards.ContinuousEffects;

namespace Cards.Cards.DM12
{
    class HypersprintWariorUzesol : Engine.Creature
    {
        public HypersprintWariorUzesol() : base("Hypersprint Warior Uzesol", 4, 1000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
