using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Domain.Companies.Exceptions
{
    public class ExceptionMessages
    {
        public static string GetCompanyNotFoundString(long id)
        {
            return $"Company with id {id} not found";
        }
    }
}
