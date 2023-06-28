using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM08
{
    class FuriousOnslaught : Spell
    {
        public FuriousOnslaught() : base("Furious Onslaught", 4, Civilization.Fire)
        {
            AddSpellAbilities(new FuriousOnslaughtOneShotEffect());
        }
    }

    class FuriousOnslaughtOneShotEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new FuriousOnslaughtContinuousEffect(game.BattleZone.GetCreatures(Applier, Race.Dragonoid).ToList()));
        }

        public override IOneShotEffect Copy()
        {
            return new FuriousOnslaughtOneShotEffect();
        }

        public override string ToString()
        {
            return "Until the end of the turn, each of your Dragonoids in the battle zone is an Armored Dragon in addition to its other races, gets +4000 power, and has \"double breaker.\"";
        }
    }

    class FuriousOnslaughtContinuousEffect : UntilEndOfTurnEffect, IRaceAddingEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        private readonly List<ICard> _cards;

        public FuriousOnslaughtContinuousEffect(List<ICard> cards)
        {
            _cards = cards;
        }

        public FuriousOnslaughtContinuousEffect(FuriousOnslaughtContinuousEffect effect) : base(effect)
        {
            _cards = effect._cards.ToList();
        }

        public void AddAbility(IGame game)
        {
            _cards.ForEach(x => x.AddGrantedAbility(new DoubleBreakerAbility()));
        }

        public void AddRace(IGame game)
        {
            _cards.ForEach(x => x.AddGrantedRace(Race.ArmoredDragon));
        }

        public override IContinuousEffect Copy()
        {
            return new FuriousOnslaughtContinuousEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            _cards.ForEach(x => x.Power += 4000);
        }

        public override string ToString()
        {
            return $"{_cards} is an Armored Dragon in addition to its other races, gets +4000 power, and has \"double breaker.\"";
        }
    }
}
