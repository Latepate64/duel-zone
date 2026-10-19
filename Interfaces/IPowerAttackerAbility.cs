namespace Interfaces;

/// <summary>
/// Power attacker +x (While attacking, this creature gets +x power.)
/// </summary>
public interface IPowerAttackerAbility : IStaticAbility
{
    int Power { get; }
}