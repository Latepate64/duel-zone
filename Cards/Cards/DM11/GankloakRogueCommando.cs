using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class GankloakRogueCommando : SilentSkillCreature
    {
        public GankloakRogueCommando() : base("Gankloak, Rogue Commando", 3, 2000, Race.Human, Civilization.Fire)
        {
            AddSilentSkillAbility(new GankloakRogueCommandoOneShotEffect());
        }
    }

    class GankloakRogueCommandoOneShotEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var creatures = game.BattleZone.GetCreatures(Ability.Controller);
            game.AddContinuousEffects(Ability, new GankloakRogueCommandoContinuousEffect(creatures.ToArray()));
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
