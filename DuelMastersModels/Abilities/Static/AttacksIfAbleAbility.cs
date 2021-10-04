namespace DuelMastersModels.Abilities.Static
{
    public class AttacksIfAbleAbility : StaticAbility
    {
        public AttacksIfAbleAbility() : base()
        {
        }

        public AttacksIfAbleAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new AttacksIfAbleAbility(this);
        }
    }
}
