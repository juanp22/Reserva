﻿$("#fk_id_crucero").change(function (e) {
    e.preventDefault();
    var form = $("#formGuardarCabina");
    console.log("cambio");
    $.ajax({
        url: "gestion_cruceros/M24_ListarCabinas/" + $("#fk_id_crucero").val(),
        data: null,
        type: 'GET',
        success: function (data) {
            console.log(data)
            $("#tablaCabinas tr").remove();
            for (var index = 0; index < data.length; index++) {
                console.log(data[index])
          
                var statusHTML = data[index]._estatus == "activo" ? "<td class='crStatus'><i class='fa fa-circle started'></i></td>"+
                                        "<td class='crAcciones'><i class='fa fa-eye'></i> <i class='fa fa-pencil'></i> <i class='fa fa-times'></i> <i class='fa fa-trash eliminar_crucero'></i></td>" : "<td class='crStatus'><i class='fa fa-circle paused'></i></td>"+
                                       "<td class='crAcciones'><i class='fa fa-eye'></i> <i class='fa fa-pencil'></i> <i class='fa fa-check'></i> <i class='fa fa-trash eliminar_crucero'></i></td>";

                console.log(statusHTML)
                html = "<tr><td style='text-align:center'>" + data[index]._nombreCabina + "</td><td style='text-align:center'>" + data[index]._precioCabina + "</td>" + statusHTML + "</tr>";
                console.log(html)
                $("#tablaCabinas").append(html);
            }
            //$('#formGuardarCabina')[0].reset();
        },
        error: function (data) {
            console.log(data);
            $('#formGuardarCabina')[0].reset();
        }
    });
});