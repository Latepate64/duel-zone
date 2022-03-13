using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class MarrowOozeTheTwister : Creature
    {
        public MarrowOozeTheTwister() : base("Marrow Ooze, the Twister", 1, 1000, Subtype.LivingDead, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new AttackPlayerAbility(new MarrowOozeTheTwisterEffect()));
        }
    }

    class MarrowOozeTheTwisterEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            game.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new AfterAttackAbility(new OneShotEffects.DestroyAreaOfEffect(new TargetFilter()), source.Source), new Engine.Durations.Once(), source.Id, source.Owner));
        }

        public override OneShotEffect Copy()
        {
            return new MarrowOozeTheTwisterEffect();
        }

        public override string ToString()
        {
            return "Destroy it after the attack.";
        }
    }
}
