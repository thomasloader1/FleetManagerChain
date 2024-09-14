using System;
using System.Collections.Generic;

namespace FleetManagerChain.Web.Context;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}
