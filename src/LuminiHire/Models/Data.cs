using Elasticsearch.Context.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuminiHire.Models
{
    public class Data
    {
        public Search search { get; set; }
        public int qntPages { get; set; }
        public int qntFounded { get; set; }
        public double timeToFind { get; set; }

        public List<Scorecard> Schools { get; set; }
    }
}
