using Common;

namespace Cards.Cards.DM03
{
    class SwordButterfly : Creature
    {
        public SwordButterfly() : base("Sword Butterfly", 3, 2000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(3000));
        }
    }
}
