<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportDetailsSpecific.aspx.cs" Inherits="ACES4.ReportDetailsSpecific" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="reportDetailsSpecificGridViewContainer">
        <script>
           
            $(window).on("load", GetViolationsByFleetDetailsSpecific);
            


        </script>
        <div id="searchContainerDetailsSpecific">
            <asp:Label ID="labelInfo" runat="server" CssClass="reportDetailsSpecificLabel" Text=""></asp:Label>
            <asp:TextBox ID="TxtBxDrCode" runat="server" CssClass="reportDetailsSpecificTxtBx"></asp:TextBox>
            <asp:Button ID="BtnGetData" runat="server" OnClick="BtnGetData_Click"  Text="Get Data" CssClass="reportDetailsSpecificBtn btncolor" BackColor="Black" ForeColor="White" /><button type="button" onclick="myFunction()"></button>
        </div>
        

        <div id="reportDetailsSpecificTopView"></div>
        <div id="reportDetailsSpecificBottomView"></div>
        <asp:Label ID="Violations" runat="server" data-test="" data-name="" CssClass="drCodeText"></asp:Label>

    </div>
</asp:Content>
