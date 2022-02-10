using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class WanderingBraineater : Creature
    {
        public WanderingBraineater() : base("Wandering Braineater", 2, Common.Civilization.Darkness, 2000, Common.Subtype.LivingDead)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
