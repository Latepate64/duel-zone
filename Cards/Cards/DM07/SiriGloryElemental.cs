using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class SiriGloryElemental : Creature
    {
        public SiriGloryElemental() : base("Siri, Glory Elemental", 6, 7000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new SiriEffect());
        }
    }

    class SiriEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public SiriEffect() : base()
        {
        }

        public SiriEffect(SiriEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            if (!Controller.ShieldZone.HasCards)
            {
                game.AddAbility(Source, new StaticAbilities.BlockerAbility());
                game.AddAbility(Source, new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
            }
        }

        public override IContinuousEffect Copy()
        {
            return new SiriEffect(this);
        }

        public override string ToString()
        {
            return "While you have no shields, this creature has \"blocker\" and \"At the end of each of your turns, you may untap this creature.\"";
        }
    }
}
