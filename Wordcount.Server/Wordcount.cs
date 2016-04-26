using System;
using System.Linq;
using System.Security.Permissions;
using Wordcount.Contracts;

namespace Wordcount.Server
{
    internal class Wordcount : IWordsCount
    {

        public Response countWords(Request rq)
        {
            Response rs = new Response();
            string[] words = rq.Text.Split(new Char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            rs.TotalCount = words.Length;
            rs.AbsolutCount = (from word in words where word == rq.CountedWord select word).Count();
            rs.RelativeCount = Math.Round(((double) rs.AbsolutCount / rs.TotalCount) * 100, 2);
            return rs;
        }

    }
}