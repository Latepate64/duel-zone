using Common;

namespace Cards.Cards.DM12
{
    class MuramasasKnife : Creature
    {
        public MuramasasKnife() : base("Muramasa's Knife", 3, 2000, Engine.Subtype.Xenoparts, Civilization.Fire)
        {
            AddThisCreatureCanAttackUntappedCreaturesAbility();
        }
    }
}
