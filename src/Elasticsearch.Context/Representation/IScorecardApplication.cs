using Elasticsearch.Context.Index;
using Elasticsearch.Context.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elasticsearch.Context.Representation
{
    public interface IScorecardApplication
    {
        public long GetCountDocs();

        ICollection<Scorecard> GetByName(string name, int from);

        public ScorecardAggregationModel GetScorecardAggregation(string name);
    }
}
