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
        ASPxTreeList1.DataSource = Data;
        ASPxTreeList1.DataBind();
        ASPxTreeList1.ExpandAll();
    }
    List<SampleDataItem> Data {
        get {
            const string key = "TreeListData";
            if(Session[key] == null)
                Session[key] = CreateData();
            return (List<SampleDataItem>)Session[key];
        }
    }

    List<SampleDataItem> CreateData() {
        List<SampleDataItem> result = new List<SampleDataItem>();
        result.Add(new SampleDataItem(Guid.NewGuid(), Guid.Empty, "root", 0));
        result.Add(new SampleDataItem(result[0], "a", 1));
        result.Add(new SampleDataItem(result[0], "b", 2));
        result.Add(new SampleDataItem(result[1], "a1", 3));
        result.Add(new SampleDataItem(result[1], "a2", 4));
        result.Add(new SampleDataItem(result[1], "a3", 5));
        result.Add(new SampleDataItem(result[2], "b1", 6));
        result.Add(new SampleDataItem(result[2], "b2", 7));
        result.Add(new SampleDataItem(result[6], "b1a", 8));
        result.Add(new SampleDataItem(result[6], "b1b", 9));
        result.Add(new SampleDataItem(result[6], "b1c", 10));
        return result;
    }

    protected void ASPxTreeList1_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e) {
        ASPxTreeList tl = (ASPxTreeList)sender;
        var nodes = tl.GetSelectedNodes(true);
        string[] arg = e.Argument.Split('|');
        SampleDataItem parentNode = tl.FindNodeByKeyValue(arg[0]).DataItem as SampleDataItem;        
        if(arg.Length > 1) {
            SampleDataItem child = tl.FindNodeByKeyValue(arg[1]).DataItem as SampleDataItem;
            child.Parent = parentNode.Pk;
        } else {            
            foreach(TreeListNode node in nodes) {
                SampleDataItem child = node.DataItem as SampleDataItem;
                child.Parent = parentNode.Pk;
            }
        }
        tl.DataBind();

    }

    protected void ASPxTreeList1_ProcessDragNode(object sender, TreeListNodeDragEventArgs e) {

        e.Handled = true;
    }
}