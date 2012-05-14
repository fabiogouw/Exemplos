using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemploMetodosNaoPublicosReflection
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Label1.Text = (string)ViewState["TESTE_PAGINA"];
        }
    }
}
