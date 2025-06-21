namespace Interfaces.Choices;

public interface IAttackTargetChoice : IChoice
{
    IAttackable Choice { get; set; }
    IEnumerable<IAttackable> Targets { get; set; }
}
