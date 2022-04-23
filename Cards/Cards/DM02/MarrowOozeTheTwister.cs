using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class MarrowOozeTheTwister : Creature
    {
        public MarrowOozeTheTwister() : base("Marrow Ooze, the Twister", 1, 1000, Race.LivingDead, Civilization.Darkness)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new WhenThisCreatureAttacksPlayerAbility(new MarrowOozeTheTwisterEffect()));
        }
    }

    class MarrowOozeTheTwisterEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(
                new DelayedTriggeredAbility(
                    new AfterAttackAbility(
                        new OneShotEffects.DestroyThisCreatureEffect(),
                        Ability.Source.Id),
                    Ability.Source,
                    Ability.Controller,
                    true));
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
