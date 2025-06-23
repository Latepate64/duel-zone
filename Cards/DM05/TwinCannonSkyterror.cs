using ContinuousEffects;

namespace Cards.DM05
{
    sealed class TwinCannonSkyterror : Creature
    {
        public TwinCannonSkyterror() : base("Twin-Cannon Skyterror", 7, 7000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
