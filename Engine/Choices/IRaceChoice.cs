using System.Collections.Generic;

namespace Engine.Choices;

public interface IRaceChoice : IChoice
{
    Race? Choice { get; set; }
    IEnumerable<Race> Excluded { get; set; }
}