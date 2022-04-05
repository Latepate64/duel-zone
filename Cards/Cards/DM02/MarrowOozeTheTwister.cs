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
            AddBlockerAbility();
            AddTriggeredAbility(new WhenThisCreatureAttacksPlayerAbility(new MarrowOozeTheTwisterEffect()));
        }
    }

    class MarrowOozeTheTwisterEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AfterAttackAbility(new OneShotEffects.DestroyThisCreatureEffect(), source.Source), source.Source, source.Controller, true));
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
