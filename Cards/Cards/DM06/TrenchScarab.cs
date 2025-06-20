using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class TrenchScarab : Engine.Creature
    {
        public TrenchScarab() : base("Trench Scarab", 3, 4000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
