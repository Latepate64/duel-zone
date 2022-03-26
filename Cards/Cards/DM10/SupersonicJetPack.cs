using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Linq;

namespace Cards.Cards.DM10
{
    class SupersonicJetPack : Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Common.Civilization.Fire)
        {
            AddSpellAbilities(new SupersonicJetPackEffect());
        }
    }

    class SupersonicJetPackEffect : GrantChoiceEffect
    {
        public SupersonicJetPackEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SupersonicJetPackEffect();
        }

        public override string ToString()
        {
            return "One of your creatures in the battle zone gets \"speed attacker\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(new CardFilters.TargetsFilter(cards)));
        }
    }

    class ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect : AbilityAddingEffect
    {
        public ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(ICardFilter filter) : base(filter, new UntilTheEndOfTheTurn(), new SpeedAttackerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"speed attacker\" until the end of the turn.";
        }
    }
}
