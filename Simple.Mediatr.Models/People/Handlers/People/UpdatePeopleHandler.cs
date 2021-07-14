using MediatR;
using Simple.Mediatr.Model.People.Commands;
using Simple.Mediatr.Model.People.Notification.People;
using Simple.Mediatr.Repository.Interface.People;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Mediatr.Model.People.Handlers.People
{
    public class UpdatePeopleHandler : IRequestHandler<UpdatePeopleCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IPeopleRepository<PeopleModel> _repository;

        public UpdatePeopleHandler(IMediator mediator, IPeopleRepository<PeopleModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var people = new PeopleModel
                {
                    PeopleId = request.PeopleId,
                    PeopleName = request.PeopleName,
                    PeopleAge = request.PeopleAge,
                    PeopleSex = request.PeopleSex
                };

                await _repository.Edit(people);

                await _mediator.Publish(new UpdatePeopleNotification
                {
                    PeopleId = people.PeopleId,
                    PeopleName = people.PeopleName,
                    PeopleAge = people.PeopleAge,
                    PeopleSex = people.PeopleSex,
                    PeopleIsValid = new UpdatePeopleNotification().PeopleIsValid

                }); ;

                return await Task.FromResult("Pessoa Alterada com Sucesso!!!!!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new UpdatePeopleNotification { PeopleId = request.PeopleId, PeopleName = request.PeopleName, PeopleIsValid = new UpdatePeopleNotification().IsValid() });
                await _mediator.Publish(new OperationErrorPeopleNotification { MsgError = ex.Message.ToString() });
                return await Task.FromResult("Ocorreu alguem problema ao salvar Pessoa");
            }
        }
    }
}
