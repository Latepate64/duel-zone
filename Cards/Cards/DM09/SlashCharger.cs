using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class SlashCharger : Charger
    {
        public SlashCharger() : base("Slash Charger", 3, Civilization.Darkness)
        {
            AddSpellAbilities(new SlashChargerEffect());
        }
    }

    class SlashChargerEffect : OneShotEffect
    {
        public SlashChargerEffect()
        {
        }

        public SlashChargerEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var player = Applier.ChoosePlayer(ToString());
            var card = Applier.ChooseCard(player.Deck.Cards, ToString());
            if (card != null)
            {
                Game.Move(Ability, ZoneType.Deck, ZoneType.Graveyard, card);
            }
            player.ShuffleOwnDeck();
        }

        public override IOneShotEffect Copy()
        {
            return new SlashChargerEffect(this);
        }

        public override string ToString()
        {
            return "Search a player's deck. You may take a card from that deck and put it into that player's graveyard. Then the player shuffles his deck.";
        }
    }
}
