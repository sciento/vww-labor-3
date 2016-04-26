using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wordcount.Contracts
{
    [ServiceContract]
    public interface IWordsCount
    {
        [OperationContract]
        [ServiceKnownType(typeof(Request))]
        Response countWords(Request word);

    }
}