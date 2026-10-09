using ContinuousEffects.CannotAttackPlayers;
using ContinuousEffects.PowerModifying;

namespace Cards.DM06
{
    sealed class TrenchScarab : Creature
    {
        public TrenchScarab() : base("Trench Scarab", 3, 4000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
