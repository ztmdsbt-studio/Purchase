using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTMDSBT.Purchase
{
  public class ApplicationContext
  {
    private static readonly ApplicationContext _current = new ApplicationContext();

    private ApplicationContext()
    { }

    public ApplicationContext Context => _current;
  }
}
