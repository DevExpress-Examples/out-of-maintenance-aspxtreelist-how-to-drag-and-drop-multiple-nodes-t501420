using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Init(object sender, EventArgs e) {
        if(!IsPostBack)
            Session.Clear();

        ASPxTreeList1.DataSource = DataHelper.GetData();
        ASPxTreeList1.DataBind();

        ASPxTreeList1.ExpandAll();
    }

    protected void ASPxTreeList1_ProcessDragNode(object sender, TreeListNodeDragEventArgs e) {

        e.Handled = true;
        var nodes = ASPxTreeList1.GetSelectedNodes();

        if (nodes.Count == 0)
            DataHelper.MoveNode(Convert.ToInt32(e.Node.Key), Convert.ToInt32(e.NewParentNode.Key));
        else
            DataHelper.MoveNodes(nodes, Convert.ToInt32(e.NewParentNode.Key));
    }

    protected void ASPxTreeList1_HtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
    {
        e.Cell.CssClass = "customClass";
    }
}