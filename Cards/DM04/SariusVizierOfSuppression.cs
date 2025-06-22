using ContinuousEffects;

namespace Cards.DM04
{
    sealed class SariusVizierOfSuppression : Engine.Creature
    {
        public SariusVizierOfSuppression() : base("Sarius, Vizier of Suppression", 2, 3000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
