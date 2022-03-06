namespace Cards.Cards.DM02
{
    class MiniTitanGett : Creature
    {
        public MiniTitanGett() : base("Mini Titan Gett", 2, 2000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            Abilities.Add(new StaticAbilities.AttacksIfAbleAbility());
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(1000));
        }
    }
}
