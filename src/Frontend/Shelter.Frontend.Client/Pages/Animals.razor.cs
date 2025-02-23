// @page "/Animals"

// @code {
//     private List<Elemento> elementos = new();

//     protected override async Task OnInitializedAsync()
//     {
//         // Simulación de carga de datos
//         elementos = await ElementoService.ObtenerElementosAsync();
//     }
// }

// <h3 class="mb-3">Listado de Elementos</h3>

// <table class="table table-striped">
//     <thead>
//         <tr>
//             <th>ID</th>
//             <th>Nombre</th>
//             <th>Descripción</th>
//         </tr>
//     </thead>
//     <tbody>
//         @foreach (var elemento in elementos)
//         {
//             <tr>
//                 <td>@elemento.Id</td>
//                 <td>@elemento.Nombre</td>
//                 <td>@elemento.Descripcion</td>
//             </tr>
//         }
//     </tbody>
// </table>
