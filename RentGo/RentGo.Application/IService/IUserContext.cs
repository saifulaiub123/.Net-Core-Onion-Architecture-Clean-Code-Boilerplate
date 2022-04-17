using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentGo.Domain.DBModel;

namespace RentGo.Application.IService
{
    public interface IUserContext
    {
        ApplicationUser User { get; }
    }
}
