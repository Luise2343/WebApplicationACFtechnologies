<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.cshtml" Inherits="System.Web.Mvc.ViewPage<NombreDeTuProyecto.Models.Cliente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Crear Cliente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Crear Cliente</h2>

    <% using (Html.BeginForm()) { %>
        <div class="form-group">
            <%: Html.LabelFor(model => model.identification) %>
            <%: Html.TextBoxFor(model => model.identification, new { @class = "form-control" }) %>
        </div>
        
        <div class="form-group">
            <%: Html.LabelFor(model => model.primerNombre) %>
            <%: Html.TextBoxFor(model => model.primerNombre, new { @class = "form-control" }) %>
        </div>

        <div class="form-group">
            <%: Html.LabelFor(model => model.primerApellido) %>
            <%: Html.TextBoxFor(model => model.primerApellido, new { @class = "form-control" }) %>
        </div>

        <div class="form-group">
            <%: Html.LabelFor(model => model.edad) %>
            <%: Html.TextBoxFor(model => model.edad, new { @class = "form-control" }) %>
        </div>

        <div class="form-group">
            <%: Html.LabelFor(model => model.fechaDeCreacion) %>
            <%: Html.TextBoxFor(model => model.fechaDeCreacion, new { @class = "form-control", type = "datetime-local" }) %>
        </div>

        <input type="submit" value="Crear" class="btn btn-primary" />
    <% } %>
</asp:Content>
