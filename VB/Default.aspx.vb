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
        ASPxTreeList1.DataSource = Data
        ASPxTreeList1.DataBind()
        ASPxTreeList1.ExpandAll()
    End Sub
    Private ReadOnly Property Data() As List(Of SampleDataItem)
        Get
            Const key As String = "TreeListData"
            If Session(key) Is Nothing Then
                Session(key) = CreateData()
            End If
            Return DirectCast(Session(key), List(Of SampleDataItem))
        End Get
    End Property

    Private Function CreateData() As List(Of SampleDataItem)
        Dim result As New List(Of SampleDataItem)()
        result.Add(New SampleDataItem(Guid.NewGuid(), Guid.Empty, "root", 0))
        result.Add(New SampleDataItem(result(0), "a", 1))
        result.Add(New SampleDataItem(result(0), "b", 2))
        result.Add(New SampleDataItem(result(1), "a1", 3))
        result.Add(New SampleDataItem(result(1), "a2", 4))
        result.Add(New SampleDataItem(result(1), "a3", 5))
        result.Add(New SampleDataItem(result(2), "b1", 6))
        result.Add(New SampleDataItem(result(2), "b2", 7))
        result.Add(New SampleDataItem(result(6), "b1a", 8))
        result.Add(New SampleDataItem(result(6), "b1b", 9))
        result.Add(New SampleDataItem(result(6), "b1c", 10))
        Return result
    End Function

    Protected Sub ASPxTreeList1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs)
        Dim tl As ASPxTreeList = DirectCast(sender, ASPxTreeList)
        Dim nodes = tl.GetSelectedNodes(True)
        Dim arg() As String = e.Argument.Split("|"c)
        Dim parentNode As SampleDataItem = TryCast(tl.FindNodeByKeyValue(arg(0)).DataItem, SampleDataItem)
        If arg.Length > 1 Then
            Dim child As SampleDataItem = TryCast(tl.FindNodeByKeyValue(arg(1)).DataItem, SampleDataItem)
            child.Parent = parentNode.Pk
        Else
            For Each node As TreeListNode In nodes
                Dim child As SampleDataItem = TryCast(node.DataItem, SampleDataItem)
                child.Parent = parentNode.Pk
            Next node
        End If
        tl.DataBind()

    End Sub

    Protected Sub ASPxTreeList1_ProcessDragNode(ByVal sender As Object, ByVal e As TreeListNodeDragEventArgs)

        e.Handled = True
    End Sub
End Class