using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class ReapAndSow : Spell
    {
        public ReapAndSow() : base("Reap and Sow", 5, Civilization.Fire, Civilization.Nature)
        {
            AddSpellAbilities(new ReapAndSowEffect());
        }
    }

    class ReapAndSowEffect : OneShotEffect
    {
        public ReapAndSowEffect()
        {
        }

        public ReapAndSowEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var player = Controller;
            var card = player.ChooseCard(game.GetOpponent(player).ManaZone.Cards, ToString());
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, card);
            player.PutFromTopOfDeckIntoManaZone(game, 1, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new ReapAndSowEffect(this);
        }

        public override string ToString()
        {
            return "Choose a card in your opponent's mana zone and put it into his graveyard. Then put the top card of your deck into your mana zone.";
        }
    }
}
