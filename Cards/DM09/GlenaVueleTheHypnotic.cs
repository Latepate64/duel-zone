using TriggeredAbilities;
using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM09
{
    class GlenaVueleTheHypnotic : EvolutionCreature
    {
        public GlenaVueleTheHypnotic() : base("Glena Vuele, the Hypnotic", 5, 8500, Race.Guardian, Civilization.Light)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(new GlenaVueleTheHypnoticEffect()));
        }
    }

    class GlenaVueleTheHypnoticEffect : OneShotEffect
    {
        public GlenaVueleTheHypnoticEffect()
        {
        }

        public GlenaVueleTheHypnoticEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            if (Controller.ChooseToTakeAction(ToString()))
            {
                Controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new GlenaVueleTheHypnoticEffect(this);
        }

        public override string ToString()
        {
            return "You may add the top card of your deck to your shields face down.";
        }
    }
}
