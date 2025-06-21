using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM02
{
    class MarrowOozeTheTwister : Creature
    {
        public MarrowOozeTheTwister() : base("Marrow Ooze, the Twister", 1, 1000, Race.LivingDead, Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenThisCreatureAttacksPlayerAbility(new MarrowOozeTheTwisterEffect()));
        }
    }

    class MarrowOozeTheTwisterEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(
                new AfterAttackDelayedTriggeredAbility(
                    new OneShotEffects.DestroyThisCreatureEffect(),
                    Ability,
                    Ability.Source.Id));
        }

        public override IOneShotEffect Copy()
        {
            return new MarrowOozeTheTwisterEffect();
        }

        public override string ToString()
        {
            return "Destroy it after the attack.";
        }
    }
}
