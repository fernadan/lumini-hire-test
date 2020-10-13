using Elasticsearch.Context.Index;
using Elasticsearch.Context.Model;
using Elasticsearch.Context.Representation;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elasticsearch.Context.Application
{
    public class ScorecardApplication : IScorecardApplication
    {
        private readonly IElasticClient _elasticClient;
        
        public ScorecardApplication(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public long GetCountDocs()
        {
            var countResponse = _elasticClient.Count<Scorecard>();

            return countResponse.Count;
        }

        public ICollection<Scorecard> GetByName(string name, int from)
        {
            var query = new QueryContainerDescriptor<Scorecard>().Term(t => t.Field(f => f.instnm).Value(name));

            var result = _elasticClient.Search<Scorecard>(s => s
                .Index(nameof(Scorecard).ToLower())
                .From(from)
                .Size(20)
                .Query(s => query));

            return result?.Documents.ToList();
        }

        public ScorecardAggregationModel GetScorecardAggregation(string name)
        {
            var query = new QueryContainerDescriptor<Scorecard>().Term(t => t.Field(f => f.instnm).Value(name));

            var countResponse = _elasticClient.Count<Scorecard>(c => c.Query(c => query));

            return new ScorecardAggregationModel { qntFounded = countResponse.Count, qntPages = Convert.ToInt32(Math.Ceiling(((decimal)countResponse.Count) / ((decimal)20))) };
        }
    }
}
