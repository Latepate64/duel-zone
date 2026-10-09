using ContinuousEffects.PowerModifying;

namespace Cards.DM08
{
    sealed class TorpedoSkyterror : Creature
    {
        public TorpedoSkyterror() : base("Torpedo Skyterror", 5, 4000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new DogarnTheMarauderEffect(2000));
        }
    }
}
