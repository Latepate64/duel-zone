using Common;
using Engine;
using Engine.Abilities;

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
            var power = source.GetController(game).ChooseNumber(ToString(), 0, 6000);
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
}
