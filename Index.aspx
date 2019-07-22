<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload id="FileUploadControl" runat="server" />
        <asp:Button runat="server" id="UploadButton" text="Upload File" onclick="UploadButton_Click" />
        <br /><br />
        <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
        <hr />



<%--        <asp:Button runat="server" id="Button1" text="Download Result" onclick="DownloadButton_Click" />--%>
        <a href="sorted-names-list.txt" download>Download Result</a>
        <%--
            <asp:Literal ID="ltrTry" runat="server"></asp:Literal>
            <asp:Button runat="server" id="Button1" text="Sort" onclick="SortButton_Click" />--%>
    </div>
    </form>
</body>
</html>
