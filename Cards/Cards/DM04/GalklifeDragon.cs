using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class GalklifeDragon : Creature
    {
        public GalklifeDragon() : base("Galklife Dragon", 7, 6000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new GalklifeDragonEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class GalklifeDragonEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public GalklifeDragonEffect() : base(new CardFilters.OpponentsBattleZoneMaxPowerCivilizationCreatureFilter(4000, Civilization.Light))
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GalklifeDragonEffect();
        }

        public override string ToString()
        {
            return "Destroy all light creatures that have power 4000 or less.";
        }
    }
}
