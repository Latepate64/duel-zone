using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class Draglide : Creature
    {
        public Draglide() : base("Draglide", 5, Civilization.Fire, 5000, Subtype.ArmoredWyvern)
        {
            Abilities.Add(new AttacksIfAbleAbility());
        }
    }
}
