using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SampleDataItem
/// </summary>
public class SampleDataItem {
    string m_title;
    int m_quantity;
    Guid m_pk;
    Guid m_parent;

    public SampleDataItem(Guid pk, Guid parent, string title, int quantity) {
        m_pk = pk;
        m_parent = parent;
        m_title = title;
        m_quantity = quantity;
    }
    public SampleDataItem(SampleDataItem parent, string title, int quantity)
        : this(Guid.NewGuid(), parent.Pk, title, quantity) { }

    public Guid Pk { get { return m_pk; } }
    public Guid Parent { get { return m_parent; } set { m_parent = value; } }
    public string Title { get { return m_title; } }
    public int Quantity { get { return m_quantity; } }
    public int Quantity2 { get { return m_quantity; } }
}