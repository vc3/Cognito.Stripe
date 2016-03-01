using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VC3.Stripe
{
	public interface IStripeEventHandler<T>
		where T : StripeObject, new()
	{
		StripeEvent<T> StripeEvent { get; set; }
	}
}
