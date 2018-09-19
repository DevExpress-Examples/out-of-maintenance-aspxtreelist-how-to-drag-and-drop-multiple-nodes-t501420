Option Infer On

Imports DevExpress.Web.ASPxTreeList
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class Data
    Public Property ID() As Integer
    Public Property ParentID() As Integer
    Public Property Title() As String
End Class

Public NotInheritable Class DataHelper

    Private Sub New()
    End Sub

    Public Shared Function GetData() As List(Of Data)
        Dim data As List(Of Data) = TryCast(HttpContext.Current.Session("Data"), List(Of Data))

        If data Is Nothing Then
            data = New List(Of Data)()

            data.Add(New Data With { _
                .ID = 1, _
                .ParentID = 0, _
                .Title = "Root" _
            })

            data.Add(New Data With { _
                .ID = 2, _
                .ParentID = 1, _
                .Title = "A" _
            })
            data.Add(New Data With { _
                .ID = 3, _
                .ParentID = 1, _
                .Title = "B" _
            })
            data.Add(New Data With { _
                .ID = 4, _
                .ParentID = 1, _
                .Title = "C" _
            })

            data.Add(New Data With { _
                .ID = 5, _
                .ParentID = 2, _
                .Title = "A1" _
            })
            data.Add(New Data With { _
                .ID = 6, _
                .ParentID = 2, _
                .Title = "A2" _
            })
            data.Add(New Data With { _
                .ID = 7, _
                .ParentID = 2, _
                .Title = "A3" _
            })

            data.Add(New Data With { _
                .ID = 8, _
                .ParentID = 3, _
                .Title = "B1" _
            })
            data.Add(New Data With { _
                .ID = 9, _
                .ParentID = 3, _
                .Title = "B2" _
            })

            data.Add(New Data With { _
                .ID = 10, _
                .ParentID = 4, _
                .Title = "C1" _
            })

            data.Add(New Data With { _
                .ID = 11, _
                .ParentID = 8, _
                .Title = "B1A" _
            })
            data.Add(New Data With { _
                .ID = 12, _
                .ParentID = 8, _
                .Title = "B1B" _
            })

            HttpContext.Current.Session("Data") = data
        End If

        Return data
    End Function

    Public Shared Sub MoveNodes(ByVal nodes As List(Of TreeListNode), ByVal parentID As Integer)
        Dim data = GetData()

        For Each node In nodes
            If nodes.Where(Function(x) CInt((x.GetValue("ID"))) = CInt((node.GetValue("ParentID")))).Count() = 0 Then
                Dim id = CInt((node.GetValue("ID")))
                Dim processedNode = data.Find(Function(x) x.ID = id)
                processedNode.ParentID = parentID
            End If
        Next node
    End Sub

    Public Shared Sub MoveNode(ByVal nodeID As Integer, ByVal parentID As Integer)
        Dim data = GetData()
        data.Find(Function(x) x.ID = nodeID).ParentID = parentID
    End Sub
End Class