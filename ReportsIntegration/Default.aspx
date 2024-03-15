<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReportsIntegration._Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        html,body,form,#div1 {
            height: 100%; 
        }
    </style>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote"  Width="100%" ShowToolBar="False">
        <ServerReport ReportServerUrl="http://desktop-sps7f6p/reportserverSSRS" ReportPath="/incidents" />
    </rsweb:ReportViewer>

    <rsweb:ReportViewer ID="ReportViewer2" runat="server"  Width="100%" ShowToolBar="False" Height="500px"></rsweb:ReportViewer>
</asp:Content>
