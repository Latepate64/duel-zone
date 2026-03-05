namespace Cards.DM08
{
    sealed class TorpedoSkyterror : Creature
    {
        public TorpedoSkyterror() : base("Torpedo Skyterror", 5, 4000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(2000));
        }
    }
}
