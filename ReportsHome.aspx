<%@ Page Title="A.C.E.S | REPORTS" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportsHome.aspx.cs" Inherits="ACES4.WebForm1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="reportsGridViewContainer">
        <!--Div that will hold the pie chart-->
        <div id="ChartTopCenter">
            <script> 
                $(window).on("load", GetFleetViolationsByMonth);
                $(window).on("load", GetViolationsByFleetJPT);
                $(window).on("load", GetViolationsByFleetWLT);
                $(window).on("load", GetViolationsByFleetPOR);
            </script>
            
        </div>
        <div id="ChartCenterLeft"></div>
        <div id="ChartCenterCenter"></div>
        <div id="ChartCenterRight"></div>
        <asp:Button ID="BTNCCL" runat="server" style="height: 26px" Text="Details" OnClick="btnCCL_Click" CssClass="btnCCL btncolor" BackColor="Black" ForeColor="White" />
        <asp:Button ID="BTNCCC" runat="server" style="height: 26px" Text="Details" OnClick="btnCCC_Click" CssClass="btnCCC btncolor" BackColor="Black" ForeColor="White" />
        <asp:Button ID="BTNCCR" runat="server" style="height: 26px" Text="Details" OnClick="btnCCR_Click" CssClass="btnCCR btncolor" BackColor="Black" ForeColor="White" />

        <asp:Label ID="ViolationsByMonth" runat="server" data-test="" CssClass="drCodeText"></asp:Label>
        <asp:Label ID="JPTViolations" runat="server" data-test="" CssClass="drCodeText"></asp:Label>
        <asp:Label ID="WLTViolations" runat="server" data-test="" CssClass="drCodeText"></asp:Label>
        <asp:Label ID="PORViolations" runat="server" data-test="" CssClass="drCodeText"></asp:Label>
        


    </div>
</asp:Content>
