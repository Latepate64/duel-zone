namespace Cards.DM08
{
    class TorpedoSkyterror : Engine.Creature
    {
        public TorpedoSkyterror() : base("Torpedo Skyterror", 5, 4000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(2000));
        }
    }
}
