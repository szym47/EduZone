using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
