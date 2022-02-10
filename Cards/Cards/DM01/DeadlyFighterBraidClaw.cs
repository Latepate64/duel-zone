using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class DeadlyFighterBraidClaw : Creature
    {
        public DeadlyFighterBraidClaw() : base("Deadly Fighter Braid Claw", 1, Common.Civilization.Fire, 1000, Common.Subtype.Dragonoid)
        {
            Abilities.Add(new AttacksIfAbleAbility());
        }
    }
}
