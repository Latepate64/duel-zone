using Engine;

namespace Cards.Cards.DM02
{
    class MiniTitanGett : Creature
    {
        public MiniTitanGett() : base("Mini Titan Gett", 2, Civilization.Fire, 2000, Subtype.Human)
        {
            Abilities.Add(new StaticAbilities.AttacksIfAbleAbility());
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(1000));
        }
    }
}
