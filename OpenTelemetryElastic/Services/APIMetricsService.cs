using System.Diagnostics.Metrics;

namespace OpenTelemetryElastic.Services
{
    public class APIMetricsService
    {
        private readonly Meter meter;

        public Counter<int> RequestCounter { get; }

        public APIMetricsService()
        {
            meter = new Meter("APIMetrics");
            RequestCounter = meter.CreateCounter<int>("RequestCounter");
        }
    }
}