using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class HydroHurricane : Spell
    {
        public HydroHurricane() : base("Hydro Hurricane", 6, Civilization.Water)
        {
            AddSpellAbilities(new HydroHurricaneFirstEffect(), new HydroHurricaneSecondEffect());
        }
    }

    class HydroHurricaneFirstEffect : OneShotEffect
    {
        public HydroHurricaneFirstEffect()
        {
        }

        public HydroHurricaneFirstEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var controller = Controller;
            var amount = game.BattleZone.GetCreatures(controller.Id).Count(x => x.HasCivilization(Civilization.Light));
            var cards = controller.ChooseCards(GetOpponent(game).ManaZone.Cards, 0, amount, ToString()).ToArray();
            game.Move(Source, ZoneType.ManaZone, ZoneType.Hand, cards);
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneFirstEffect(this);
        }

        public override string ToString()
        {
            return "For each light creature you have in the battle zone, you may choose a card in your opponent's mana zone and return it to his hand.";
        }
    }

    class HydroHurricaneSecondEffect : OneShotEffect
    {
        public HydroHurricaneSecondEffect()
        {
        }

        public HydroHurricaneSecondEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var controller = Controller;
            var amount = game.BattleZone.GetCreatures(controller.Id).Count(x => x.HasCivilization(Civilization.Darkness));
            var creatures = controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id), 0, amount, ToString()).ToArray();
            game.Move(Source, ZoneType.ManaZone, ZoneType.Hand, creatures);
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneSecondEffect(this);
        }

        public override string ToString()
        {
            return "For each darkness creature you have in the battle zone, you may choose one of your opponent's creatures in the battle zone and return it to his hand.";
        }
    }
}
