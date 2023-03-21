using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btc.Instructions.Data.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<bool> IsExist(int id);
    }
}
