using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class BallomMasterOfDeath : EvolutionCreature
    {
        public BallomMasterOfDeath() : base("Ballom, Master of Death", 8, 12000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new BallomMasterOfDeathEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class BallomMasterOfDeathEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public BallomMasterOfDeathEffect() : base(new CardFilters.BattleZoneNonCivilizationCreatureFilter(Civilization.Darkness))
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BallomMasterOfDeathEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures except darkness creatures.";
        }
    }
}
