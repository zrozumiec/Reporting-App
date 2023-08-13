using MediatR;
using ReportingApp.Application.CQRS.Queries.Failure.GetAcceptedFailures;
using ReportingApp.Application.CQRS.Queries.Solution.GetAUserAcceptedSolutions;
using ReportingApp.Application.DTO;

namespace ReportingApp.UI.Models.Calendar
{
    public class CalendarEvent
    {
        private readonly List<string> colors = new ()
        {
            "red",
            "DarkKhaki",
            "orange",
            "blue",
            "green",
            "black",
            "gray",
            "pink",
        };

        public string Id { get; }

        public string GroupId { get; }

        public string Title { get; }

        public string Start { get; }

        public string End { get; }

        public string URL { get; }

        public string Color { get; }

        public CalendarEvent(FailureSolutionDto solution)
        {
            this.Id = solution.Id.ToString();
            this.Title = solution.Failure.Name;
            this.GroupId = solution.Failure.Id.ToString();
            this.Start = solution.ExpectedStartTime.ToString("yyyy-MM-dd");
            this.End = solution.ExpectedEndTime.ToString("yyyy-MM-dd");
            this.URL = solution.Description;
            this.Color = this.colors.OrderBy(s => Guid.NewGuid()).First();
        }

        public static async Task<IEnumerable<CalendarEvent>> FillCalendarWithSolutionsEvents(string userId, IMediator mediator)
        {
            var solutions = await mediator.Send(new GetUserAcceptedSolutionsQuery(userId));
            var solutionsEvents = new List<CalendarEvent>();

            foreach (var solution in solutions)
            {
                solutionsEvents.Add(new CalendarEvent(solution));
            }

            return solutionsEvents.AsEnumerable();
        }

        public static async Task<IEnumerable<CalendarEvent>> FillCalendarWithFailureEvents(string userId, IMediator mediator)
        {
            var solutions = await mediator.Send(new GetAcceptedFailuresQuery(userId));
            var failureEvents = new List<CalendarEvent>();

            foreach (var solution in solutions)
            {
                failureEvents.Add(new CalendarEvent(solution));
            }

            return failureEvents.AsEnumerable();
        }
    }
}
