using MediatR;

namespace Simple.Mediatr.Model.People.Notification.People
{
    public class UpdatePeopleNotification : INotification
    {
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }
        public int PeopleAge { get; set; }
        public EnumSex PeopleSex { get; set; }
        public bool PeopleIsValid { get; set; } = true;
        public bool IsValid() => !PeopleIsValid;
    }
}
