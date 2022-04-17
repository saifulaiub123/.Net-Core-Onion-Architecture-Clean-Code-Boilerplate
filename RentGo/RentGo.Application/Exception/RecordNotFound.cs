using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentGo.Domain.Constant;

namespace RentGo.Application.Exception
{
    public class RecordNotFound : DomainException
    {
        public RecordNotFound(string msg = "The record you are trying to update is not found") : base(msg)
        {

        }

        public override int ToHttpStatusCode()
        {
            return AppStatusCode.BadRequestStatusCode;
        }
    }
}