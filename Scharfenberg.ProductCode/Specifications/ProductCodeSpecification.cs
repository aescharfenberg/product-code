using System;
using System.Text.RegularExpressions;
using Scharfenberg.Extensions;
using Scharfenberg.ProductCode.Contracts;

namespace Scharfenberg.ProductCode.Models
{
    internal class ProductCodeSpecification : IProductCodeSpecification
    {        
        public string Moniker { get; }

        public int CodeLength { get; }

        public string UccName { get; }

        private Regex Regex { get; }

        private Func<string, char> CheckDigitFunc { get; }

        internal ProductCodeSpecification(string moniker, int codeLength, Func<string, char> checkDigitFunc, string uccName = null)
        {
            Moniker = moniker;
            CodeLength = codeLength;
            UccName = uccName;
            Regex = new Regex($"^[0-9]{{{codeLength}}}$");
            CheckDigitFunc = checkDigitFunc;
        }

        public IProductCode Parse(string code)
        {
            throw new System.NotImplementedException();
        }

        public bool TryParse(string code, out IProductCode productCode)
        {
            throw new System.NotImplementedException();
        }

        public bool IsValid(string code)
        {
            return Regex.IsMatch(code) && CheckDigitFunc(code) == Convert.ToChar(code.Right(1));
        }
    }
}