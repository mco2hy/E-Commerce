using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Interfaces
{
   public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        IOutgoingEmailRepository OutgoingEmailRepository { get; set; }
        int Complete();
    }
}
