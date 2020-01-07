using System;
using System.Collections.Generic;
using System.Text;
using Braintree;
using Microsoft.Extensions.Options;

namespace BulkyBook.Utility
{
    public class BrainTreeGate : IBrainTreeGate
    {
        public BrainTreeSettings Options { get; set; }

        private IBraintreeGateway BraintreeGateway { get; set; }

        public BrainTreeGate(IOptions<BrainTreeSettings> options)
        {
            Options = options.Value;
        }
        public IBraintreeGateway CreateGateway()
        {
            return new BraintreeGateway(Options.Environment, Options.MerchantId, Options.PublicKey, Options.PrivateKey);
        }

        public IBraintreeGateway GetGateway()
        {
            if (BraintreeGateway == null)
            {
                BraintreeGateway = CreateGateway();
            }
            return BraintreeGateway;
        }
    }
}
