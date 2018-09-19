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
            DataHelper.MoveNode(CType(e.Node.Key, Integer), CType(e.NewParentNode.Key, Integer))
        Else
            DataHelper.MoveNodes(nodes, CType(e.NewParentNode.Key, Integer))
        End If
    End Sub
    Protected Sub ASPxTreeList1_HtmlDataCellPrepared(sender As Object, e As TreeListHtmlDataCellEventArgs)
        e.Cell.CssClass = "customClass"
    End Sub
End Class