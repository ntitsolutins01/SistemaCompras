﻿using System;
using System.Linq;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicitacaoCompraAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public void RegistrarCompra (SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Add(entity);
        }
    }
}
