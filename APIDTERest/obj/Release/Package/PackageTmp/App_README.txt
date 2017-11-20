Ha agregado un complemento de Office correctamente.

Para usar la funcionalidad y estilos de Office para una página HTML determinada, agregue las siguientes
referencias a la sección <head> de la página, ajustando las rutas de acceso según sea necesario:

    <!-- Referencias de Office: -->
    <link href="Content/Office.css" rel="stylesheet" type="text/css" />
    <script src="https://appsforoffice.microsoft.com/lib/1/hosted/office.js"></script>

    <!-- Para habilitar la depuración sin conexión mediante una referencia local a Office.js, use:                  -->
    <!--    <script src="Scripts/Office/MicrosoftAjax.js" type="text/javascript"></script>       -->
    <!--    <script src="Scripts/Office/1/office.js" type="text/javascript"></script>          -->


Tenga en cuenta que se debe llamar a la función Office.initialize antes de cualquier 
interacción de JavaScript con la API de Office (una vez por página):

    Office.initialize = function (reason) {
        $(document).ready(function () {
            // Agregar aquí la lógica de inicialización.
        });
    };
