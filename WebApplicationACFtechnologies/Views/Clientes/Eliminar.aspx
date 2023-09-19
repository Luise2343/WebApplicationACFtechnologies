<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.cshtml" Inherits="System.Web.Mvc.ViewPage<NombreDeTuProyecto.Models.Cliente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Eliminar Cliente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Eliminar Cliente</h2>

    <% using (Html.BeginForm()) { %>
        <div class="form-group">
            <%: Html.LabelFor(model => model.identification) %>
            <%: Html.DisplayFor(model => model.identification, new { @class = "form-control", disabled = "disabled" }) %>
        </div>
        
        <div class="form-group">
            <%: Html.LabelFor(model => model.primerNombre) %>
            <%: Html.DisplayFor(model => model.primerNombre, new { @class = "form-control", disabled = "disabled" }) %>
        </div>

        <div class="form-group">
            <%: Html.LabelFor(model => model.primerApellido) %>
            <%: Html.DisplayFor(model => model.primerApellido, new { @class = "form-control", disabled = "disabled" }) %>
        </div>

        <div class="form-group">
            <%: Html.LabelFor(model => model.edad) %>
            <%: Html.DisplayFor(model => model.edad, new { @class = "form-control", disabled = "disabled" }) %>
        </div>

        <div class="form-group">
            <%: Html.LabelFor(model => model.fechaDeCreacion) %>
            <%: Html.DisplayFor(model => model.fechaDeCreacion, new { @class = "form-control", disabled = "disabled" }) %>
        </div>

        <input type="submit" value="Eliminar" class="btn btn-danger" />
    <% } %>
</asp:Content>
