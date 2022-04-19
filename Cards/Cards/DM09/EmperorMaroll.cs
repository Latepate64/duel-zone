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
        public override void Apply(IGame game, IAbility source)
        {
            game.Move(source, ZoneType.BattleZone, ZoneType.Hand, (game.CurrentTurn.CurrentPhase as AttackPhase).BlockingCreature);
        }

        public override IOneShotEffect Copy()
        {
            return new EmperorMarollEffect();
        }

        public override string ToString()
        {
            return "Return the blocking creature to its owner's hand.";
        }
    }
}
