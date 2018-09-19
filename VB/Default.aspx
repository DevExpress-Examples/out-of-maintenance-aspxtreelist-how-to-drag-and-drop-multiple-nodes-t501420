<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxTreeList - How to drag and drop multiple nodes</title>
    <script>
        function OnStartDragNode(s, e) {
            setTimeout(function () { CustomStartDragNode(s, e); }, 200);
        }

        function CustomStartDragNode(s, e) {
            var div = document.getElementById('form1').nextElementSibling;
            if (!div) return;
            var selectedKeys = s.GetVisibleSelectedNodeKeys();
            if (selectedKeys.indexOf(e.nodeKey) == -1 || selectedKeys.length == 0) return;
            table = div.childNodes[0];
            var row = table.rows[0];
            cloneRow = row.cloneNode(true);
            table.deleteRow(0);
            for (i = 0; i < selectedKeys.length; i++) {
                var row = cloneRow.cloneNode(true);
                var object = s.GetNodeHtmlElement(selectedKeys[i]).getElementsByClassName("customClass");
                for (var j = 0; j < object.length; j++) {
                    row.cells[j].innerHTML = object[j].innerHTML;
                }
                table.appendChild(row);
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxTreeList ID="ASPxTreeList1" runat="server" KeyFieldName="ID" ParentFieldName="ParentID" 
                AutoGenerateColumns="False"
                OnProcessDragNode="ASPxTreeList1_ProcessDragNode"
                OnHtmlDataCellPrepared="ASPxTreeList1_HtmlDataCellPrepared"
                Width="227px">
                <SettingsSelection Enabled="true" />
                <ClientSideEvents StartDragNode="OnStartDragNode" />
                <SettingsEditing AllowNodeDragDrop="True" />
                <Columns>
                    <dx:TreeListTextColumn FieldName="Title" VisibleIndex="0">
                    </dx:TreeListTextColumn>
                </Columns>
            </dx:ASPxTreeList>
        </div>
    </form>
</body>
</html>