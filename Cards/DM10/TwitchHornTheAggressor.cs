namespace Cards.DM10
{
    sealed class TwitchHornTheAggressor : Creature
    {
        public TwitchHornTheAggressor() : base("Twitch Horn, the Aggressor", 6, 2000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.JigglyTotemEffect(2000));
        }
    }
}
