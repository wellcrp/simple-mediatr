using MediatR;

namespace Simple.Mediatr.Model.People.Commands
{
    public class CreatePeopleCommand : IRequest<string>
    {
        public string PeopleName { get; set; }
        public int PeopleAge { get; set; }
        public EnumSex PeopleSex { get; set; }
    }
}
