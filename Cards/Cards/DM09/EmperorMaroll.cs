using Engine;
using Engine.Abilities;
using Engine.Steps;

namespace Cards.Cards.DM09
{
    class EmperorMaroll : EvolutionCreature
    {
        public EmperorMaroll() : base("Emperor Maroll", 3, 5000, Race.CyberLord, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new EmperorMarollEffect()));
        }
    }

    class EmperorMarollEffect : OneShotEffect
    {
        public EmperorMarollEffect()
        {
        }

        public EmperorMarollEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, (game.CurrentTurn.CurrentPhase as AttackPhase).BlockingCreature);
        }

        public override IOneShotEffect Copy()
        {
            return new EmperorMarollEffect(this);
        }

        public override string ToString()
        {
            return "Return the blocking creature to its owner's hand.";
        }
    }
}
