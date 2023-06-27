using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class Flametropus : Creature
    {
        public Flametropus() : base("Flametropus", 4, 3000, Race.RockBeast, Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new FlametropusOneShotEffect());
        }
    }

    class FlametropusOneShotEffect : OneShotEffect
    {
        public FlametropusOneShotEffect()
        {
        }

        public FlametropusOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var player = Applier;
            var card = player.ChooseCardOptionally(player.ManaZone.Cards, ToString());
            if (card != null)
            {
                game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, card);
                game.AddContinuousEffects(Ability, new FlametropusContinuousEffect(Ability.Source));                 
            }
        }

        public override IOneShotEffect Copy()
        {
            return new FlametropusOneShotEffect(this);
        }

        public override string ToString()
        {
            return "You may put a card from your mana zone into your graveyard. If you do, this creature gets \"power attacker +3000\" and \"double breaker\" until the end of the turn.";
        }
    }

    class FlametropusContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public FlametropusContinuousEffect(FlametropusContinuousEffect effect) : base(effect)
        {
        }

        public FlametropusContinuousEffect(ICard card) : base(card, new PowerAttackerAbility(3000), new DoubleBreakerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new FlametropusContinuousEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"power attacker +3000\" and \"double breaker\" until the end of the turn.";
        }
    }
}
