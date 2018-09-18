using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Data
{
    public int ID { set; get; }
    public int ParentID { set; get; }
    public string Title { set; get; }
}

public static class DataHelper
{
    public static List<Data> GetData()
    {
        List<Data> data = HttpContext.Current.Session["Data"] as List<Data>;

        if (data == null)
        {
            data = new List<Data>();

            data.Add(new Data { ID = 1, ParentID = 0, Title = "Root" });

            data.Add(new Data { ID = 2, ParentID = 1, Title = "A" });
            data.Add(new Data { ID = 3, ParentID = 1, Title = "B" });
            data.Add(new Data { ID = 4, ParentID = 1, Title = "C" });

            data.Add(new Data { ID = 5, ParentID = 2, Title = "A1" });
            data.Add(new Data { ID = 6, ParentID = 2, Title = "A2" });
            data.Add(new Data { ID = 7, ParentID = 2, Title = "A3" });

            data.Add(new Data { ID = 8, ParentID = 3, Title = "B1" });
            data.Add(new Data { ID = 9, ParentID = 3, Title = "B2" });

            data.Add(new Data { ID = 10, ParentID = 4, Title = "C1" });

            data.Add(new Data { ID = 11, ParentID = 8, Title = "B1A" });
            data.Add(new Data { ID = 12, ParentID = 8, Title = "B1B" });

            HttpContext.Current.Session["Data"] = data;
        }

        return data;
    }

    public static void MoveNodes(List<TreeListNode> nodes, int parentID)
    {
        var data = GetData();

        foreach (var node in nodes)
        {
            if (nodes.Where(x => (int)x.GetValue("ID") == (int)node.GetValue("ParentID")).Count() == 0)
            {
                var id = (int)node.GetValue("ID");
                var processedNode = data.Find(x => x.ID == id);
                processedNode.ParentID = parentID;
            }
        }
    }

    public static void MoveNode(int nodeID, int parentID)
    {
        var data = GetData();
        data.Find(x => x.ID == nodeID).ParentID = parentID;
    }
}