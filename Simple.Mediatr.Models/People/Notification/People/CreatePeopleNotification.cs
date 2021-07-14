using MediatR;

namespace Simple.Mediatr.Model.People.Notification.People
{
    public class CreatePeopleNotification : INotification
    {
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }
        public int PeopleAge { get; set; }
        public EnumSex PeopleSex { get; set; }
    }
}
