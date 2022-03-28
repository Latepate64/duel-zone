using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class Cratersaur : Creature
    {
        public Cratersaur() : base("Cratersaur", 3, 2000, Subtype.RockBeast, Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouHaveNoShieldsEffect(new StaticAbilities.ThisCreatureCanAttackUntappedCreaturesAbility()));
            AddPowerAttackerAbility(3000);
        }
    }
}
