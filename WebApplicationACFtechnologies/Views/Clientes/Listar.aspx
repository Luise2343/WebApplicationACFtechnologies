<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.cshtml" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NombreDeTuProyecto.Models.Cliente>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Lista de Clientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lista de Clientes</h2>

    <table class="table">
        <thead>
            <tr>
                <th>ID</th>
                <th>Identificación</th>
                <th>Primer Nombre</th>
                <th>Primer Apellido</th>
                <th>Edad</th>
                <th>Fecha de Creación</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var cliente in Model) { %>
                <tr>
                    <td><%: cliente.id %></td>
                    <td><%: cliente.identification %></td>
                    <td><%: cliente.primerNombre %></td>
                    <td><%: cliente.primerApellido %></td>
                    <td><%: cliente.edad %></td>
                    <td><%: cliente.fechaDeCreacion.ToString("dd/MM/yyyy HH:mm:ss") %></td>
                    <td>                       
                        <a href="<%: Url.Action("Editar", new { id = cliente.id }) %>">Editar</a>
                        <a href="<%: Url.Action("Eliminar", new { id = cliente.id }) %>">Eliminar</a>
                    </td>
                </tr>
            <% } %>
        </tbody>
    </table>
</asp:Content>
