<%@ Page Title="A.C.E.S | NEW INCIDENT" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Incident.aspx.cs" Inherits="ACES4.Incident" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    
    $(document).ready(function () {
        $("input[id$='TxtBxDate']").datepicker();
    });
    
</script>

    <%-- Check Boxes --%>
    <div id="IncidentGridViewContainer"> 
        <%-- Notes --%>
        <div id="drCodeContainer">
            <asp:Label ID="lblDrCode" runat="server" Text="Driver Code:" CssClass="drCodeText"></asp:Label>
            <asp:TextBox ID="TxtBxDrCode" runat="server" CssClass="drCodeTextBox"></asp:TextBox>
            <asp:Button ID="BtnGetData" runat="server" OnClick="BtnGetData_Click" Text="Get Data" CssClass="drCodebtn btncolor" BackColor="Black" ForeColor="White" />
        </div>

       <%-- Btn Sumbit --%>
        <div class="incidentFieldsContainer">
                <asp:Label ID="lblDate" runat="server" Text="Incident Date:"></asp:Label>
                <asp:Label ID="lblDrName" runat="server" Text="Driver Name:"></asp:Label>
                <asp:Label ID="lblFMInit" runat="server" Text="FM Inititals:"></asp:Label>
                <asp:Label ID="lblFMName" runat="server" Text="FM Name:"></asp:Label>
                <asp:Label ID="lblFMCode" runat="server" Text="FM Code:"></asp:Label>
                <asp:Label ID="lblFleetCode" runat="server" Text="Fleet Code:"></asp:Label>
                <asp:Label ID="lblHOSViolation" runat="server" Text="HOS Violations:"></asp:Label>
                <asp:Label ID="lblInspect" runat="server" Text="Failed Inspections:"></asp:Label>
                <asp:Label ID="lblCitattion" runat="server" Text="Citations:"></asp:Label>
        </div>

        <%-- Error Messages --%>
        <div class="txtFieldContainer">
                <asp:TextBox ID="TxtBxDate" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxDrName" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxFMInit" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxFMName" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxFMCode" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxFleetCode" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxHOSViolation" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxInspect" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxCitation" runat="server"></asp:TextBox>
        </div>

        <%-- Btn Sumbit --%>
        <div id="checkBoxes">
            <asp:CheckBoxList ID="CkBxList" runat="server" CellSpacing="25" Width="100%" >
                <asp:ListItem>Counseled</asp:ListItem>
                <asp:ListItem>Terminated</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <%-- Error Messages --%>
        <div id="notesContainer">
            <p id="notesHeader">Notes</p>
            <asp:TextBox ID="TxtBxNotes" runat="server" TextMode="MultiLine" CssClass="notesTextBox" MaxLength="255" ></asp:TextBox>
        </div>
        <%-- Btn Sumbit --%>
            <asp:Button ID="btnAdd" runat="server" style="height: 26px" Text="Submit" OnClick="btnAdd_Click" CssClass="btnSubmit btncolor" BackColor="Black" ForeColor="White" />
        <%--<button type="button" onclick="myFunction()">Press</button>--%>

        <%-- Error Messages --%>
        <div id="errorMessages">
            <asp:Label ID="lblErrMessage" runat="server" Text="Message" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
