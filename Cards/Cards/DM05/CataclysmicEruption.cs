using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM05
{
    class CataclysmicEruption : Spell
    {
        public CataclysmicEruption() : base("Cataclysmic Eruption", 8, Civilization.Fire)
        {
            AddSpellAbilities(new CataclysmicEruptionEffect());
        }
    }

    class CataclysmicEruptionEffect : OneShotEffect
    {
        public CataclysmicEruptionEffect()
        {
        }

        public CataclysmicEruptionEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var controller = Controller;
            var amount = game.BattleZone.GetCreatures(controller.Id).Count(x => x.HasCivilization(Civilization.Nature));
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, controller.ChooseCards(GetOpponent(game).ManaZone.Cards, 0, amount, ToString()).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new CataclysmicEruptionEffect(this);
        }

        public override string ToString()
        {
            return "For each nature creature you have in the battle zone, you may choose a card in your opponent's mana zone and put it into his graveyard.";
        }
    }
}
