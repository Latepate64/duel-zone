using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class BlazeCannon : Spell
    {
        public BlazeCannon() : base("Blaze Cannon", 7, Civilization.Fire)
        {
            AddStaticAbilities(new BlazeCannonRestrictionEffect());
            AddSpellAbilities(new BlazeCannonBuffEffect());
        }
    }

    class BlazeCannonRestrictionEffect : ContinuousEffect, ICannotUseCardEffect
    {
        public BlazeCannonRestrictionEffect(BlazeCannonRestrictionEffect effect) : base(effect)
        {
        }

        public BlazeCannonRestrictionEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BlazeCannonRestrictionEffect(this);
        }

        public override string ToString()
        {
            return "You can cast this spell only if all the cards in your mana zone are fire cards.";
        }

        public bool Applies(IGame game)
        {
            return !game.GetAbility(SourceAbility).GetController(game).ManaZone.Cards.All(x => x.HasCivilization(Civilization.Fire));
        }
    }

    class BlazeCannonBuffEffect : OneShotAreaOfEffect
    {
        public BlazeCannonBuffEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(GetAffectedCards(game, source).ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new BlazeCannonBuffEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
        }
    }
}
