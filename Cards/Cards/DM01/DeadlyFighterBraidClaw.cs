using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DeadlyFighterBraidClaw : Creature
    {
        public DeadlyFighterBraidClaw() : base("Deadly Fighter Braid Claw", 1, 1000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddAbilities(new AttacksIfAbleAbility());
        }
    }
}
