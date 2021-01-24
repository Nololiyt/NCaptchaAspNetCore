using System;

namespace Example
{
    public class NCaptchaSettings
    {
        public long? TicketsLifeTime { get; init; }
        internal TimeSpan? ConvertedTicketsLifeTime
            => this.TicketsLifeTime.HasValue ? new TimeSpan(this.TicketsLifeTime.Value) : null;
        public long? AnswersLifeTime { get; init; }
        internal TimeSpan? ConvertedAnswersLifeTime
            => this.AnswersLifeTime.HasValue ? new TimeSpan(this.AnswersLifeTime.Value) : null;
        public string? AllowedCharacters { get; init; }
    }
}
