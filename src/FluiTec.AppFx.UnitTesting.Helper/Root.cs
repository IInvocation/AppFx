using System.Collections.Generic;

namespace FluiTec.AppFx.UnitTesting.Helper
{
    /// <summary>
    ///     A json root-object.
    /// </summary>
    public class Root
    {
        public IEnumerable<ConnectionString> ConnectionStrings { get; set; }
    }
}