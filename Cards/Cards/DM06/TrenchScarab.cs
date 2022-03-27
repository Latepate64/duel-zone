using Common;

namespace Cards.Cards.DM06
{
    class TrenchScarab : Creature
    {
        public TrenchScarab() : base("Trench Scarab", 3, 4000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotAttackPlayersAbility(), new StaticAbilities.PowerAttackerAbility(4000));
        }
    }
}
