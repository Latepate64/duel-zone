namespace Cards.Cards.DM02
{
    class MiniTitanGett : Creature
    {
        public MiniTitanGett() : base("Mini Titan Gett", 2, Common.Civilization.Fire, 2000, Common.Subtype.Human)
        {
            Abilities.Add(new StaticAbilities.AttacksIfAbleAbility());
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(1000));
        }
    }
}
