namespace Simple.Mediatr.Model.People.Notification.People
{
    public class DeletePeopleNotification
    {
        public int PeopleId { get; set; }
        public bool PeopleIsValid { get; set; } = true;
        public bool IsValid() => !PeopleIsValid;
    }
}
