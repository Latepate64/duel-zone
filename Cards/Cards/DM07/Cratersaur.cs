using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM07
{
    class Cratersaur : Creature
    {
        public Cratersaur() : base("Cratersaur", 3, 2000, Subtype.RockBeast, Civilization.Fire)
        {
            AddStaticAbilities(new CratersaurEffect());
        }
    }

    class CratersaurEffect : CanAttackUntappedCreaturesEffect, IAbilityAddingEffect
    {
        public CratersaurEffect() : base(new CardFilters.OpponentsBattleZoneUntappedCreatureFilter(), new Durations.Indefinite(), new Conditions.FilterNoneCondition(new CardFilters.OwnersShieldZoneCardFilter()))
        {
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.PowerAttackerAbility(3000)));
        }

        public override IContinuousEffect Copy()
        {
            return new CratersaurEffect();
        }

        public override string ToString()
        {
            return "While you have no shields, this creature can attack untapped creatures and has \"Power attacker +3000.\"";
        }
    }
}
