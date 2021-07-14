using MediatR;

namespace Simple.Mediatr.Model.People.Commands
{
    public class DeletePeopleCommand : IRequest<string>
    {
        public int PeopleId { get; set; }
    }
}
