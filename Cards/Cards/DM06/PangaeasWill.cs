using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class PangaeasWill : Spell
    {
        public PangaeasWill() : base("Pangaea's Will", 3, Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new PangaeasWillEffect());
        }
    }

    class PangaeasWillEffect : OneShotEffect
    {
        public PangaeasWillEffect()
        {
        }

        public PangaeasWillEffect(PangaeasWillEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var card = Applier.ChooseCard(game.BattleZone.GetChoosableEvolutionCreaturesControlledByChoosersOpponent(game, Applier), ToString());
            if (card != null)
            {
                game.MoveTopCard(card, ZoneType.ManaZone, Ability);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new PangaeasWillEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's evolution creatures in the battle zone and put the top card of that creature into your opponent's mana zone.";
        }
    }
}
