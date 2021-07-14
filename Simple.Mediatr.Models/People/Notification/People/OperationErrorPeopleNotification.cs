using MediatR;

namespace Simple.Mediatr.Model.People.Notification.People
{
    public class OperationErrorPeopleNotification : INotification
    {
        public string MsgError { get; set; }
    }
}
