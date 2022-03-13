using Common;

namespace Cards.Cards.DM03
{
    class BabyZoppe : Creature
    {
        public BabyZoppe() : base("Baby Zoppe", 3, 2000, Subtype.FireBird, Civilization.Fire)
        {
            AddAbilities(new Engine.Abilities.StaticAbility(new Engine.ContinuousEffects.PowerModifyingEffect(2000, new Conditions.AllOfCivilizationCondition(Civilization.Fire))));
        }
    }
}
