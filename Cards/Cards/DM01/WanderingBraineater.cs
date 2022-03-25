using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class WanderingBraineater : Creature
    {
        public WanderingBraineater() : base("Wandering Braineater", 2, 2000, Common.Subtype.LivingDead, Common.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackCreaturesAbility(), new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
