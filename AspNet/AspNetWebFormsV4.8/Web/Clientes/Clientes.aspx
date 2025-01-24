<%@ Page Language="C#"  MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="AspNetWebFormsV4._8.Web.Clientes.Clientes" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h6>Agregar Cliente</h6>
    <asp:TextBox ID="txtRazonSocial" runat="server" Placeholder="Razón Social"></asp:TextBox>
    <asp:TextBox ID="txtRFC" runat="server" Placeholder="RFC"></asp:TextBox>
    <asp:TextBox ID="txtFechaCreacion" runat="server" TextMode="Date"></asp:TextBox>
    <asp:DropDownList ID="ddlTipoCliente" runat="server"></asp:DropDownList>
    <asp:Button ID="btnAddCliente" runat="server" Text="Agregar" OnClick="btnAddCliente_Click" />

    <h6>Listado Clientes</h6>
    <asp:GridView ID="gvClientes" runat="server" CssClass="gridview-style" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDeleting="gvClientes_RowDeleting" OnRowEditing="gvClientes_RowEditing" OnRowUpdating="gvClientes_RowUpdating" 
    OnRowCancelingEdit="gvClientes_RowCancelingEdit" OnRowDataBound="gvClientes_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID"/>
            <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
            <asp:BoundField DataField="RFC" HeaderText="RFC" />
            <%--<asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" />--%>
            <asp:TemplateField HeaderText="Fecha Creación">
                <ItemTemplate>
                    <%# Eval("FechaCreacion", "{0:yyyy-MM-dd}") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFechaCreacion" runat="server" Text='<%# Bind("FechaCreacion", "{0:yyyy-MM-dd}") %>' TextMode="Date" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo Cliente">
                <ItemTemplate>
                    <%# Eval("TipoCliente.TipoCliente") %> <!-- Muestra el nombre del tipo de cliente -->
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlTipoCliente" runat="server"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ShowCancelButton="true"/>
        </Columns>
    </asp:GridView>
</asp:Content>
