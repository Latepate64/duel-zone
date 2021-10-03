namespace DuelMastersModels.Abilities
{
    public abstract class SpellAbility : ResolvableAbility
    {
        protected SpellAbility() : base()
        { }

        protected SpellAbility(SpellAbility ability) : base(ability)
        { }
    }
}
