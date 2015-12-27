using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTMDSBT.Purchase.Models;

namespace ZTMDSBT.Purchase
{
  public class ApplicationContext
  {
    private ApplicationContext()
    { }

    public static ApplicationContext Context { get; } = new ApplicationContext();

    public List<User> LoginedUsers { get; } = new List<User>();
  }
}
