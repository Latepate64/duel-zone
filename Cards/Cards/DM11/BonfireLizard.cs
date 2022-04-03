using Common;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class BonfireLizard : WaveStrikerCreature
    {
        public BonfireLizard() : base("Bonfire Lizard", 6, 4000, Subtype.MeltWarrior, Civilization.Fire)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BonfireLizardEffect()));
        }
    }

    class BonfireLizardEffect : OneShotEffects.DestroyEffect
    {
        public BonfireLizardEffect() : base(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 0, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BonfireLizardEffect();
        }

        public override string ToString()
        {
            return "Destroy up to 2 of your opponent's creatures that have \"blocker.\"";
        }
    }
}
