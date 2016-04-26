using System;
using System.Runtime.Serialization;

namespace Wordcount.Contracts
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string CountedWord { get; set; }

    }
}