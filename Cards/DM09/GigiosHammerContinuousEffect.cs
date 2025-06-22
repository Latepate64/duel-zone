using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM09;

public class GigiosHammerContinuousEffect : UntilEndOfTurnEffect, IAttacksIfAbleEffect, IAbilityAddingEffect
{
    private readonly Race _race;

    public GigiosHammerContinuousEffect(GigiosHammerContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public GigiosHammerContinuousEffect(Race race) : base()
    {
        _race = race;
    }

    public void AddAbility(IGame game)
    {
        game.BattleZone.GetCreatures(_race).ToList().ForEach(x => x.AddGrantedAbility(
            new StaticAbility(new PowerAttackerEffect(4000))));
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature.HasRace(_race);
    }

    public override IContinuousEffect Copy()
    {
        return new GigiosHammerContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"Each {_race} of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
    }
}
