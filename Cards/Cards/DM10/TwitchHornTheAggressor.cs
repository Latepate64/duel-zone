using Common;

namespace Cards.Cards.DM10
{
    class TwitchHornTheAggressor : Creature
    {
        public TwitchHornTheAggressor() : base("Twitch Horn, the Aggressor", 6, 2000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.JigglyTotemEffect(2000));
        }
    }
}
