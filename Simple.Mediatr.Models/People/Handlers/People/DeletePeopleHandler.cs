using MediatR;
using Simple.Mediatr.Model.People.Commands;
using Simple.Mediatr.Model.People.Notification.People;
using Simple.Mediatr.Repository.Interface.People;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Mediatr.Model.People.Handlers.People
{
    public class DeletePeopleHandler : IRequestHandler<DeletePeopleCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IPeopleRepository<PeopleModel> _repository;

        public DeletePeopleHandler(IMediator mediator, IPeopleRepository<PeopleModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeletePeopleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.PeopleId);

                await _mediator.Publish(new DeletePeopleNotification
                {
                    PeopleId = request.PeopleId,
                    PeopleIsValid = new DeletePeopleNotification().PeopleIsValid
                }); ;

                return await Task.FromResult("Pessoa Excluida com Sucesso!!!!!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new DeletePeopleNotification { PeopleId = request.PeopleId, PeopleIsValid = new UpdatePeopleNotification().IsValid() });
                await _mediator.Publish(new OperationErrorPeopleNotification { MsgError = ex.Message.ToString() });
             
                return await Task.FromResult("Ocorreu alguem problema ao salvar Pessoa");
            }
        }
    }
}
