using ContinuousEffects;
using TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM04
{
    class ThreeEyedDragonfly : Creature
    {
        public ThreeEyedDragonfly() : base("Three-Eyed Dragonfly", 5, 4000, Race.GiantInsect, Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new ThreeEyedDragonflyOneShotEffect()));
        }
    }

    class ThreeEyedDragonflyOneShotEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var creature = Controller.ChooseCardOptionally(game.BattleZone.GetOtherCreatures(Ability.Controller.Id, Ability.Source.Id), ToString());
            if (creature != null)
            {
                game.Destroy(Ability, creature as ICreature);
                game.AddContinuousEffects(Ability, new ThreeEyedDragonflyContinuousEffect(Ability.Source as ICreature));
            }
        }

        public override IOneShotEffect Copy()
        {
            return new ThreeEyedDragonflyOneShotEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your other creatures. If you do, this creature gets +2000 power and has \"double breaker\" until the end of the turn.";
        }
    }

    class ThreeEyedDragonflyContinuousEffect : GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect
    {
        private readonly ICreature _card;

        public ThreeEyedDragonflyContinuousEffect(ThreeEyedDragonflyContinuousEffect effect) : base(effect)
        {
            _card = effect._card;
        }

        public ThreeEyedDragonflyContinuousEffect(ICreature card) : base(2000)
        {
            _card = card;
        }

        public override IContinuousEffect Copy()
        {
            return new ThreeEyedDragonflyContinuousEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets +2000 power and has \"double breaker\" until the end of the turn.";
        }

        protected override List<ICreature> GetAffectedCards(IGame game)
        {
            return [_card];
        }
    }
}
