using MediatR;
using Simple.Mediatr.Model.People.Commands;
using Simple.Mediatr.Model.People.Notification.People;
using Simple.Mediatr.Repository.Interface.People;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Mediatr.Model.People.Handlers
{
    public class CreatePeopleHandler : IRequestHandler<CreatePeopleCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IPeopleRepository<PeopleModel> _repository;

        public CreatePeopleHandler(IMediator mediator, IPeopleRepository<PeopleModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var people = new PeopleModel
                {
                    PeopleName = request.PeopleName,
                    PeopleAge = request.PeopleAge,
                    PeopleSex = request.PeopleSex
                };

                await _repository.Add(people);

                await _mediator.Publish(new CreatePeopleNotification
                {
                    PeopleId = people.PeopleId,
                    PeopleName = people.PeopleName,
                    PeopleAge = people.PeopleAge,
                    PeopleSex = people.PeopleSex
                });

                return await Task.FromResult("Pessoa Criada com Sucesso!!!!!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new OperationErrorPeopleNotification { MsgError = ex.Message.ToString() });
                return await Task.FromResult("Ocorreu alguem problema ao salvar Pessoa");
            }
        }
    }
}
