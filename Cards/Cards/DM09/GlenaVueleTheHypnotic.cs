using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class GlenaVueleTheHypnotic : EvolutionCreature
    {
        public GlenaVueleTheHypnotic() : base("Glena Vuele, the Hypnotic", 5, 8500, Race.Guardian, Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(new GlenaVueleTheHypnoticEffect()));
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
            if (GetController(game).ChooseToTakeAction(ToString()))
            {
                GetController(game).PutFromTopOfDeckIntoShieldZone(1, game, GetSourceAbility(game));
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
