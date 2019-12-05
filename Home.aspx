<%@ Page Title="A.C.E.S | HOME" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ACES4.Load" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content  ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Uncomment to add Title heading --%>
    <%--<h4 id="HomeGridViewTitle">Last 50 Incidents</h4>--%>
    <!--Container for driver incident data-->
    <div id="HomeGridViewContainer">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="Conn" AllowSorting="True" DataKeyNames="IncidentNum" BorderStyle="Solid" CellSpacing="15" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" RowStyle-Width="50%" Height="454px" Width="100%" >
            <HeaderStyle Height="50px" />
            <Columns>
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="IncidentNum, ManagerCode" DataNavigateUrlFormatString="Edit.aspx?IncidentNum={0}&ManagerCode={1}" ControlStyle-Width="50%" ControlStyle-Font-Underline ="false" >
<ControlStyle Font-Underline="False" Width="50%"></ControlStyle>
                </asp:HyperLinkField>
                <asp:BoundField DataField="IncidentNum" HeaderText="IncidentNum" SortExpression="IncidentNum" InsertVisible="False" ReadOnly="True" Visible="False"></asp:BoundField>
                <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" SortExpression="EntryDate" Visible="False"></asp:BoundField>
                <asp:BoundField DataField="RefDate" HeaderText="RefDate" SortExpression="RefDate" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="DriverCode" HeaderText="DriverCode" SortExpression="DriverCode" />
                <asp:BoundField DataField="DriverName" HeaderText="DriverName" SortExpression="DriverName" />
                <asp:BoundField DataField="ManagerCode" HeaderText="ManagerCode" SortExpression="ManagerCode" />
                <asp:BoundField DataField="FltMgrInits" HeaderText="FltMgrInits" SortExpression="FltMgrInits" />
                <asp:BoundField DataField="Fleet" HeaderText="Fleet" SortExpression="Fleet" />
                <asp:CheckBoxField DataField="Counseled" HeaderText="Counseled" SortExpression="Counseled" />
                <asp:CheckBoxField DataField="Termed" HeaderText="Termed" SortExpression="Termed" />
                <asp:BoundField DataField="HOSViolation" HeaderText="HOSViolation" SortExpression="HOSViolation" />
                <asp:BoundField DataField="FailedInspection" HeaderText="FailedInspection" SortExpression="FailedInspection" />
                <asp:BoundField DataField="Citation" HeaderText="Citation" SortExpression="Citation" />
            </Columns>
            <AlternatingRowStyle BackColor="#99EBFF" />
            <RowStyle BackColor="#CCF5FF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Height="50px"  HorizontalAlign="Center" />
        </asp:GridView>
        <asp:SqlDataSource ID="Conn" runat="server" ConnectionString="<%$ ConnectionStrings:wilsonlogistics %>" SelectCommand="SELECT * FROM [Incidents] ORDER BY [RefDate] DESC"></asp:SqlDataSource>
    </div>
    <div id="SearchContainer">
        <asp:Label ID="lblDrCode" runat="server" Text="Driver Code:" CssClass="drCodeText"></asp:Label>
        <asp:TextBox ID="TxtBxDrCode" runat="server" CssClass="drCodeTextBox"></asp:TextBox>
        <asp:Button ID="BtnGetData" runat="server" OnClick="BtnGetData_Click" Text="Get Data" CssClass="drCodebtn btncolor" BackColor="Black" ForeColor="White" /><button type="button" onclick="myFunction()"></button>
        <asp:SqlDataSource ID="Conn2" runat="server" ConnectionString="<%$ ConnectionStrings:wilsonlogistics %>" SelectCommand="sp_IncidentByDriverCode" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtBxDrCode" PropertyName="Text" Name="DrCode" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
