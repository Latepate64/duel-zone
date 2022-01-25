using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class DeadlyFighterBraidClaw : Creature
    {
        public DeadlyFighterBraidClaw() : base("Deadly Fighter Braid Claw", 1, Civilization.Fire, 1000, Subtype.Dragonoid)
        {
            Abilities.Add(new AttacksIfAbleAbility());
        }
    }
}
