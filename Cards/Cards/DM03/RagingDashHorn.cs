using Common;

namespace Cards.Cards.DM03
{
    class RagingDashHorn : Creature
    {
        public RagingDashHorn() : base("Raging Dash-Horn", 5, 4000, Subtype.HornedBeast, Civilization.Nature)
        {
            var condition = new Conditions.AllOfCivilizationCondition(Civilization.Nature);
            AddAbilities(new Engine.Abilities.StaticAbility(new Engine.ContinuousEffects.PowerModifyingEffect(3000, condition)), new StaticAbilities.DoubleBreakerAbility(condition));
        }
    }
}
