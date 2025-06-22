using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable, IRaceable
{
    public int Power { get; }
    public Race Race { get; }

    public WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(int power, Race race) : base()
    {
        Race = race;
        Power = power;
    }

    public WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect effect) : base(effect)
    {
        Race = effect.Race;
        Power = effect.Power;
    }

    public override string ToString()
    {
        return $"While you have at least one {Race} in the battle zone, this creature gets +{Power} power during its attacks.";
    }

    public override ContinuousEffect Copy()
    {
        return new WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        throw new NotImplementedException();
        // if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && game.BattleZone.GetCreatures(Ability.Id).Any(x => x.HasRace(Race)))
        // {
        //     (Source as ICreature).IncreasePower(Power);
        // }
    }
}
