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
        public override object Apply(Game game, Ability source)
        {
            game.AddDelayedTriggeredAbility(new AfterAttackAbility(new OneShotEffects.DestroyAreaOfEffect(new TargetFilter()), source.Source), new Engine.Durations.Once());
            return null;
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
