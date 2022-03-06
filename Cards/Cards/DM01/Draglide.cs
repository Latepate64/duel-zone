using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Draglide : Creature
    {
        public Draglide() : base("Draglide", 5, Common.Civilization.Fire, 5000, Common.Subtype.ArmoredWyvern)
        {
            Abilities.Add(new AttacksIfAbleAbility());
        }
    }
}
