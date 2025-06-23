using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class HydroHurricaneSecondEffect : OneShotEffect
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
        var creatures = controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(
            game, GetOpponent(game).Id), 0, amount, ToString()).ToArray();
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, creatures);
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
