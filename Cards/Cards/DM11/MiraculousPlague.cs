using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MiraculousPlague : Spell
    {
        public MiraculousPlague() : base("Miraculous Plague", 7, Civilization.Water, Civilization.Darkness)
        {
            AddSpellAbilities(new MiraculousPlagueEffect());
        }
    }

    class MiraculousPlagueEffect : OneShotEffect
    {
        public MiraculousPlagueEffect()
        {
        }

        public override void Apply(IGame game)
        {
            var controller = Controller;
            var opponent = GetOpponent(game);

            var creatures = controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, opponent.Id), 2, 2, ToString());
            var toHand = opponent.ChooseCard(creatures, ToString());
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, toHand);
            game.Destroy(Ability, creatures.Where(x => x != toHand).ToArray());

            var cards = controller.ChooseCards(opponent.ManaZone.Cards, 2, 2, ToString());
            var manaToHand = opponent.ChooseCard(cards, ToString());
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, manaToHand);
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, cards.Where(x => x != manaToHand).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousPlagueEffect();
        }

        public override string ToString()
        {
            return "Choose 2 of your opponent's creatures in the battle zone. Your opponent chooses one of them, puts it into his hand, and destroys the other one. Then choose 2 cards in your opponent's mana zone. Your opponent chooses one of them, puts it into his hand, and puts the other one into his graveyard.";
        }
    }
}
