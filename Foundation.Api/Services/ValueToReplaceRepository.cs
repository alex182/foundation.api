﻿namespace Foundation.Api.Services
{
    using Foundation.Api.Data;
    using Foundation.Api.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ValueToReplaceRepository : IValueToReplaceRepository
    {
        private ValueToReplaceDbContext _context;
        private readonly SieveProcessor _sieveProcessor;

        public ValueToReplaceRepository(ValueToReplaceDbContext context,
            SieveProcessor sieveProcessor)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
            _sieveProcessor = sieveProcessor ??
                throw new ArgumentNullException(nameof(sieveProcessor));
        }

        public async Task<ValueToReplace> GetValueToReplaceAsync(int valueToReplaceId)
        {
            return await _context.ValueToReplaces.FirstOrDefaultAsync(lambdaInitialsToReplace => lambdaInitialsToReplace.ValueToReplaceId == valueToReplaceId);
        }

        public ValueToReplace GetValueToReplace(int valueToReplaceId)
        {
            return _context.ValueToReplaces.FirstOrDefault(lambdaInitialsToReplace => lambdaInitialsToReplace.ValueToReplaceId == valueToReplaceId);
        }

        public IEnumerable<ValueToReplace> GetValueToReplaces()
        {
            return _context.ValueToReplaces.ToList();
        }
    }
}
