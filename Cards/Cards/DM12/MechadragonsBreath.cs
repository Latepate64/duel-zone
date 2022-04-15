using Engine;
using Engine.Abilities;
using Engine.Choices;

namespace Cards.Cards.DM12
{
    class MechadragonsBreath : Spell
    {
        public MechadragonsBreath() : base("Mechadragon's Breath", 6, Civilization.Fire)
        {
            AddSpellAbilities(new MechadragonsBreathEffect());
        }
    }

    class MechadragonsBreathEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var power = source.GetController(game).ChooseNumber(new MechadragonsBreathChoice(source.GetController(game), ToString()));
            return new OneShotEffects.DestroyAllCreaturesThatHaveExactPower(power).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new MechadragonsBreathEffect();
        }

        public override string ToString()
        {
            return "Choose a number less than or equal to 6000. Destroy all creatures that have that power.";
        }
    }

    class MechadragonsBreathChoice : NumberChoice
    {
        public MechadragonsBreathChoice(NumberChoice choice) : base(choice)
        {
        }

        public MechadragonsBreathChoice(IPlayer maker, string description) : base(maker, description)
        {
        }

        public override bool IsValid()
        {
            return base.IsValid() && Choice <= 6000;
        }
    }
}
