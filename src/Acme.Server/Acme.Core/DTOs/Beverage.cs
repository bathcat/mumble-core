using System;

namespace Acme.Core;

public class Beverage
{
    public Guid ID { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = String.Empty;
    public string Description { get; init; } = String.Empty;
}
