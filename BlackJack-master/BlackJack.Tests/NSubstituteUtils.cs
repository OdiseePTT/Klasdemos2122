﻿using NSubstitute;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.Tests
{
    internal class NSubstituteUtils
    {
        public static DbSet<T> GenerateMockDbSet<T>(List<T> data) where T : class
        {
            var dbSet = Substitute.For<DbSet<T>, IQueryable<T>>();

            ((IQueryable<T>)dbSet).GetEnumerator().Returns(data.GetEnumerator());
            ((IQueryable<T>)dbSet).ElementType.Returns(data.AsQueryable().ElementType);
            ((IQueryable<T>)dbSet).Provider.Returns(data.AsQueryable().Provider);
            ((IQueryable<T>)dbSet).Expression.Returns(data.AsQueryable().Expression);

            return dbSet;
        }

    }
}
