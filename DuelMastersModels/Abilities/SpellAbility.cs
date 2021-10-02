namespace DuelMastersModels.Abilities
{
    public abstract class SpellAbility : NonStaticAbility
    {
        protected SpellAbility() : base()
        { }

        protected SpellAbility(SpellAbility ability) : base(ability)
        { }
    }
}
