<%@ Page Title="Scanner Container Page" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Container.aspx.cs" Inherits="ScannerSite.Container" %>
<asp:Content ID="HomeContent" ContentPlaceHolderID="head" runat="server">
    <title>Container Commands</title>
    <meta name="keywords" content="ContiTech Container Command Page" />
	<meta name="description" content="ContiTech Container Command Page" />
	<meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
	<meta content="C#" name="CODE_LANGUAGE" />
	<meta content="JavaScript" name="vs_defaultClientScript" />
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
	<link href="Styles.css" type="text/css" rel="stylesheet" />
	<style type="text/css">
	    TD#topnav1 A:link { BACKGROUND: #000; COLOR: #fff  }
	    TD#topnav1 A:visited { BACKGROUND: #000; COLOR: #fff }
	    TD#topnav2 A:link { BACKGROUND: #000; COLOR: #fff }
	    TD#topnav2 A:visited { BACKGROUND: #000; COLOR: #fff }
    </style>
</asp:Content>
<asp:Content ID="ContCmdPage" ContentPlaceHolderID="PageContentHolder" runat="server" HorizontalAlign="center">

    <asp:Panel ID="ProductPanel" runat="server" DefaultButton="btnView">

        <asp:Button style="margin-left: 75px; margin-bottom: 8px; margin-top: 5px" ID="btnView" runat="server" OnClick="btnView_Click" Text="View Contents" height="40px" Width="150px" Font-Size="Medium" Font-Bold="true"/>

        <asp:Button style="margin-left: 75px; margin-bottom: 8px" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Product" height="40px" Width="150px" Font-Size="Medium" Font-Bold="true"/>
        
        <asp:Button style="margin-left: 75px; margin-bottom: 8px" ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove Product" height="40px" Width="150px" Font-Size="Medium" Font-Bold="true"/>

        <asp:Button style="margin-left: 75px; margin-bottom: 5px" ID="btnMove" runat="server" OnClick="btnMove_Click" Text="Move Container" height="40px" Width="150px" Font-Size="Medium" Font-Bold="true"/>

		<table>

			<tr>
				<td><asp:Label ID="lblLocationHeader" runat="server">Location:</asp:Label></td>
				<td><asp:TextBox ID="tbLocationData" runat="server" Width="50"></asp:TextBox></td>
			</tr>

		</table>

    </asp:Panel>

</asp:Content>
