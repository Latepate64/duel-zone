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
        public override void Apply(IGame game, IAbility source)
        {
            new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect().Apply(game, source);
            source.GetController(game).PutFromTopOfDeckIntoManaZone(game, 1, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ReapAndSowEffect();
        }

        public override string ToString()
        {
            return "Choose a card in your opponent's mana zone and put it into his graveyard. Then put the top card of your deck into your mana zone.";
        }
    }
}
