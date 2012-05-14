using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace ExemploMetodosNaoPublicosReflection
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            //this.Page.ViewState["TESTE_PAGINA"] = TextBox1.Text;    // dá erro
            var viewstate = ObterViewStatePagina();
            viewstate["TESTE_PAGINA"] = TextBox1.Text;
        }

        private StateBag ObterViewStatePagina()
        {
            PropertyInfo property = typeof(Page).GetProperty("ViewState",
                BindingFlags.NonPublic | BindingFlags.Instance);
            return (StateBag)property.GetValue(this.Page, new object[] { });
        }
    }
}