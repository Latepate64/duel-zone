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
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AfterAttackAbility(new OneShotEffects.DestroyAreaOfEffect(new TargetFilter()), source.Source), source.Source, source.Owner, new Durations.Indefinite(), true));
            return null;
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
