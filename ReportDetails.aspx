<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportDetails.aspx.cs" Inherits="ACES4.ReportDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="reportDetailsGridViewContainer">
        <script>
           
            
            $(window).on("load", GetViolationsByFleetDetails);

            function test() {
                //alert(document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-test").split(","));
                alert(document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-test").split(","));
                alert(document.getElementById("ContentPlaceHolder1_Violations").getAttribute("data-name"));
            }

        </script>
       

        <div id="reportDetailsTopView"></div>
        <div id="reportDetailsBottomView"></div>
        <asp:Label ID="Violations" runat="server" data-test="" data-name="" CssClass="drCodeText"></asp:Label>

    </div>
</asp:Content>
