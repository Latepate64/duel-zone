using Common;

namespace Cards.Cards.DM03
{
    class Mudman : Creature
    {
        public Mudman() : base("Mudman", 4, 2000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddAbilities(new Engine.Abilities.StaticAbility(new Engine.ContinuousEffects.PowerModifyingEffect(2000, new Conditions.AllOfCivilizationCondition(Civilization.Darkness))));
        }
    }
}
