using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LogWebService
{
    [ServiceContract]
    public interface ILogReaderService
    {
        [OperationContract]
        void DoWork();
    }
}
