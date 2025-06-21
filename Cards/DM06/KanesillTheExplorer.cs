using ContinuousEffects;

namespace Cards.DM06
{
    class KanesillTheExplorer : Engine.Creature
    {
        public KanesillTheExplorer() : base("Kanesill, the Explorer", 3, 4000, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
