namespace Cards.Cards.DM08
{
    class TorpedoSkyterror : Engine.Creature
    {
        public TorpedoSkyterror() : base("Torpedo Skyterror", 5, 4000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(2000));
        }
    }
}
