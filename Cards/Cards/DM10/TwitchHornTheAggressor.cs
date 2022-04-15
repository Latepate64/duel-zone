namespace Cards.Cards.DM10
{
    class TwitchHornTheAggressor : Creature
    {
        public TwitchHornTheAggressor() : base("Twitch Horn, the Aggressor", 6, 2000, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.JigglyTotemEffect(2000));
        }
    }
}
