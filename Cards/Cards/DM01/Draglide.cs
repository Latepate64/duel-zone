using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class Draglide : Creature
    {
        public Draglide() : base("Draglide", 5, Civilization.Fire, 5000, Subtype.ArmoredWyvern)
        {
            Abilities.Add(new AttacksIfAbleAbility());
        }
    }
}
