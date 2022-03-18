using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SistemaCompra.Infra.Data.UoW;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaoRepository;

        public RegistrarCompraCommandHandler(SolicitacaoCompraAgg.ISolicitacaoCompraRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.solicitacaoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var obj = new SolicitacaoCompraAgg.SolicitacaoCompra(request.UsuarioSolicitante,request.NomeFornecedor);
            solicitacaoRepository.RegistrarCompra(obj);

            Commit();
            PublishEvents(obj.Events);

            return Task.FromResult(true);
        }
    }
}
