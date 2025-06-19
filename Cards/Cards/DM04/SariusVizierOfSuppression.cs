using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class SariusVizierOfSuppression : Engine.Creature
    {
        public SariusVizierOfSuppression() : base("Sarius, Vizier of Suppression", 2, 3000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
