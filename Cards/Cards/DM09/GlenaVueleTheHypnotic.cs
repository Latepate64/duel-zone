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
        public override void Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).ChooseToTakeAction(ToString()))
            {
                source.GetController(game).PutFromTopOfDeckIntoShieldZone(1, game, source);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new GlenaVueleTheHypnoticEffect();
        }

        public override string ToString()
        {
            return "You may add the top card of your deck to your shields face down.";
        }
    }
}
