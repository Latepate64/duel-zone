using Common;

namespace Cards.Cards.DM07
{
    class Cratersaur : Creature
    {
        public Cratersaur() : base("Cratersaur", 3, 2000, Subtype.RockBeast, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.WhileYouHaveNoShieldsAbility(new StaticAbilities.ThisCreatureCanAttackUntappedCreaturesAbility(), new StaticAbilities.PowerAttackerAbility(3000)));
        }
    }
}
