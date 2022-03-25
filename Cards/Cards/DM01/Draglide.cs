using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Draglide : Creature
    {
        public Draglide() : base("Draglide", 5, 5000, Common.Subtype.ArmoredWyvern, Common.Civilization.Fire)
        {
            AddAbilities(new ThisCreatureAttacksEachTurnIfAbleAbility());
        }
    }
}
