using System.Collections.Generic;
using ZTMDSBT.Purchase.Models;

namespace ZTMDSBT.Purchase
{
  public class ApplicationContext
  {
    private ApplicationContext()
    { }

    public static ApplicationContext Current { get; } = new ApplicationContext();

    public List<User> LoginedUsers { get; } = new List<User>();
  }
}
