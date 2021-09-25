namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class ThisCreatureCannotAttackPlayers : StaticAbility
    {
        internal ThisCreatureCannotAttackPlayers(System.Guid source) : base(source)
        { }

        public override Ability Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
