namespace DuelMastersModels.Abilities
{
    public abstract class ResolvableAbility : Ability
    {
        public Resolvable Resolvable { get; set; }

        public bool FinishResolution { get; set; }

        protected ResolvableAbility(Resolvable resolvable) : base()
        {
            Resolvable = resolvable;
        }

        protected ResolvableAbility(ResolvableAbility ability) : base(ability)
        {
            Resolvable = ability.Resolvable.Copy();
            FinishResolution = ability.FinishResolution;
        }

        public void Resolve(Duel duel)
        {
            Resolvable.Resolve(duel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Resolvable.Dispose();
                Resolvable = null;
            }
        }
    }
}
