Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for SampleDataItem
''' </summary>
Public Class SampleDataItem
    Private m_title As String
    Private m_quantity As Integer
    Private m_pk As Guid
    Private m_parent As Guid

    Public Sub New(ByVal pk As Guid, ByVal parent As Guid, ByVal title As String, ByVal quantity As Integer)
        m_pk = pk
        m_parent = parent
        m_title = title
        m_quantity = quantity
    End Sub
    Public Sub New(ByVal parent As SampleDataItem, ByVal title As String, ByVal quantity As Integer)
        Me.New(Guid.NewGuid(), parent.Pk, title, quantity)
    End Sub

    Public ReadOnly Property Pk() As Guid
        Get
            Return m_pk
        End Get
    End Property
    Public Property Parent() As Guid
        Get
            Return m_parent
        End Get
        Set(ByVal value As Guid)
            m_parent = value
        End Set
    End Property
    Public ReadOnly Property Title() As String
        Get
            Return m_title
        End Get
    End Property
    Public ReadOnly Property Quantity() As Integer
        Get
            Return m_quantity
        End Get
    End Property
    Public ReadOnly Property Quantity2() As Integer
        Get
            Return m_quantity
        End Get
    End Property
End Class