using System;
using System.Runtime.Serialization;

namespace Wordcount.Contracts
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public int AbsolutCount { get; set; }
        [DataMember]
        public double RelativeCount { get; set; }

    }
}