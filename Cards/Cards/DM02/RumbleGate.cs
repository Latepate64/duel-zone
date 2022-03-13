using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class RumbleGate : Spell
    {
        public RumbleGate() : base("Rumble Gate", 4, Civilization.Fire)
        {
            AddAbilities(new SpellAbility(new GrantPowerAreaOfEffect(1000)), new SpellAbility(new RumbleGateEffect()));
        }
    }

    class RumbleGateEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            game.AddContinuousEffects(source, new Engine.ContinuousEffects.CanAttackUntappedCreaturesEffect(new CardFilters.OwnersBattleZoneCreatureThatCanAttackCreaturesFilter(), new CardFilters.OpponentsBattleZoneUntappedCreatureFilter()));
        }

        public override OneShotEffect Copy()
        {
            return new RumbleGateEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone that can attack creatures can attack untapped creatures this turn.";
        }
    }
}
