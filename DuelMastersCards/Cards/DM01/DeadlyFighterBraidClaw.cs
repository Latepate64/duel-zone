using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class DeadlyFighterBraidClaw : Creature
    {
        public DeadlyFighterBraidClaw() : base("Deadly Fighter Braid Claw", 1, Civilization.Fire, 1000, Subtype.Dragonoid)
        {
            Abilities.Add(new AttacksIfAbleAbility());
        }
    }
}
