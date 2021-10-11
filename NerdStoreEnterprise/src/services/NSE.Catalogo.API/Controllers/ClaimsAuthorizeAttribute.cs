using System;

namespace NSE.Catalogo.API.Controllers
{
    internal class ClaimsAuthorizeAttribute : Attribute
    {
        private string v1;
        private string v2;

        public ClaimsAuthorizeAttribute(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}