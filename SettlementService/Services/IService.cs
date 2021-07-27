using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Threading.Tasks;

namespace Services
{
    public interface IService
    {
        Task<(bool, string)> BookForSettlement(Request request);
    }
}