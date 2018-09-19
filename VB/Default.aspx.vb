Option Infer On

Imports DevExpress.Web.ASPxTreeList
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Session.Clear()
        End If

        ASPxTreeList1.DataSource = DataHelper.GetData()
        ASPxTreeList1.DataBind()

        ASPxTreeList1.ExpandAll()
    End Sub

    Protected Sub ASPxTreeList1_ProcessDragNode(ByVal sender As Object, ByVal e As TreeListNodeDragEventArgs)

        e.Handled = True
        Dim nodes = ASPxTreeList1.GetSelectedNodes()

        If nodes.Count = 0 Then
            DataHelper.MoveNode(Convert.ToInt32(e.Node.Key), Convert.ToInt32(e.NewParentNode.Key))
        Else
            DataHelper.MoveNodes(nodes, Convert.ToInt32(e.NewParentNode.Key))
        End If
    End Sub

    Protected Sub ASPxTreeList1_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As TreeListHtmlDataCellEventArgs)
        e.Cell.CssClass = "customClass"
    End Sub
End Class