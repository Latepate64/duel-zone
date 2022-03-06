namespace Cards.Cards.DM02
{
    class MiniTitanGett : Creature
    {
        public MiniTitanGett() : base("Mini Titan Gett", 2, 2000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.AttacksIfAbleAbility());
            AddAbilities(new StaticAbilities.PowerAttackerAbility(1000));
        }
    }
}
