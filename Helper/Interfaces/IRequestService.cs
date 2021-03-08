using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Interfaces
{
    public interface IRequestService
    {
        string SendRequest<T>(object data);
    }
}
