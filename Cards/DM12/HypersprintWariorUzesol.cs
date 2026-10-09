using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM12
{
    sealed class HypersprintWariorUzesol : Creature
    {
        public HypersprintWariorUzesol() : base("Hypersprint Warior Uzesol", 4, 1000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddAbilities(new SpeedAttackerAbility());
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
