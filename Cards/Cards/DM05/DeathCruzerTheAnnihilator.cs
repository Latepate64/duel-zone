using Common;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class DeathCruzerTheAnnihilator : Creature
    {
        public DeathCruzerTheAnnihilator() : base("Death Cruzer, the Annihilator", 7, 13000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DeathCruzerTheAnnihilatorEffect()), new StaticAbilities.TripleBreakerAbility());
        }
    }

    class DeathCruzerTheAnnihilatorEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public DeathCruzerTheAnnihilatorEffect() : base(new CardFilters.OwnersOtherBattleZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DeathCruzerTheAnnihilatorEffect();
        }

        public override string ToString()
        {
            return "Destroy all your other creatures.";
        }
    }
}
