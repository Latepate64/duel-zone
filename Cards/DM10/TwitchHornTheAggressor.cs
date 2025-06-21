namespace Cards.DM10
{
    class TwitchHornTheAggressor : Engine.Creature
    {
        public TwitchHornTheAggressor() : base("Twitch Horn, the Aggressor", 6, 2000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.JigglyTotemEffect(2000));
        }
    }
}
