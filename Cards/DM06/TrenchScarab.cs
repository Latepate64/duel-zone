using ContinuousEffects;

namespace Cards.DM06
{
    sealed class TrenchScarab : Engine.Creature
    {
        public TrenchScarab() : base("Trench Scarab", 3, 4000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
