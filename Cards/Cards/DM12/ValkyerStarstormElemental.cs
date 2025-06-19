using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM12
{
    class ValkyerStarstormElemental : Engine.Creature
    {
        public ValkyerStarstormElemental() : base("Valkyer, Starstorm Elemental", 5, 7000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
