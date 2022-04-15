using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class GankloakRogueCommando : SilentSkillCreature
    {
        public GankloakRogueCommando() : base("Gankloak, Rogue Commando", 3, 2000, Engine.Subtype.Human, Engine.Civilization.Fire)
        {
            AddSilentSkillAbility(new GankloakRogueCommandoOneShotEffect());
        }
    }

    class GankloakRogueCommandoOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var creatures = game.BattleZone.GetCreatures(source.Controller);
            game.AddContinuousEffects(source, new GankloakRogueCommandoContinuousEffect(creatures.ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new GankloakRogueCommandoOneShotEffect();
        }

        public override string ToString()
        {
            return "Each of your fire creatures in the battle zone gets \"double breaker\" until the end of the turn.";
        }
    }

    class GankloakRogueCommandoContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public GankloakRogueCommandoContinuousEffect(params ICard[] cards) : base(new StaticAbilities.DoubleBreakerAbility(), cards)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new GankloakRogueCommandoContinuousEffect();
        }

        public override string ToString()
        {
            return "Each of your fire creatures in the battle zone gets \"double breaker\" until the end of the turn.";
        }
    }
}
