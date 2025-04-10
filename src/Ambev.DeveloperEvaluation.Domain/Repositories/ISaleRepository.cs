﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> AddAsync(Sale sale, CancellationToken cancellationToken = default);

        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Sale>> GetAllAsync(CancellationToken cancellationToken);
    }
}
