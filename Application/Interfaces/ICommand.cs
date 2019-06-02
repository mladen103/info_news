using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    // for insert, update, delete.. just request parameter
    public interface ICommand<TRequest>
    {
        void Execute(TRequest request);
    }

    // for get and get all.. request and response parameters
    public interface ICommand<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
