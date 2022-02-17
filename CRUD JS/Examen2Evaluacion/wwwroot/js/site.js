 window.onload = inicializaEventos;

function inicializaEventos() {
    document.getElementById("anadir").addEventListener("click", insertar, false);
    mostrar();
    document.getElementById("selector").addEventListener("change", filtrar, false);
    
}

function eliminar(id) {
    var divResultado = document.getElementById("ResultadoOperacion");

    var miLlamada = new XMLHttpRequest();
    var url = "http://localhost:64299/api/Planta/" + id;
    miLlamada.open("DELETE", url);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            divResultado.innerHTML = "Cargando";
        } else if (miLlamada.status == 200) {//OK
            alert("Planta " + id + " actualizada")
        } else if (miLlamada.status == 404) {//NO ENCONTRADO
            divResultado.innerHTML = "No se ha encontrado la persona a borrar";
        } else if (miLlamada.status = 400) {//HA ESCRITO "Ajadasiod"
            divResultado.innerHTML = "Escribe un id numerico valido";
        }
    };
    miLlamada.send();
} 



function insertar() {

    var miLlamada = new XMLHttpRequest();

     miLlamada.open("POST", "http://localhost:64299/api/Planta/");

     miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    var nombre = document.createElement('input');
    nombre.id = "inputnombre";
    nombre.placeholder = "Nombre";
    var descripcion = document.createElement('input');
    descripcion.id = "inputdescripcion";
    descripcion.placeholder = "Descripcion";
    var idCategoria = document.createElement('input')
    idCategoria.id = "inputcategoria";
    idCategoria.placeholder = "Id Categoria";
    var precio = document.createElement('input');
    precio.id = "inputprecio";
    precio.placeholder = "Precio"
    var buttonAnadir = document.createElement('button')
    buttonAnadir.textContent = "Anadir";
    buttonAnadir.addEventListener("click", function () {



        var json = JSON.stringify({ nombrePlanta: nombre.value, descripcion: descripcion.value, idCategoria: idCategoria.value, precio: precio.value });

        // Definicion estados

        miLlamada.onreadystatechange = function () {

            if (miLlamada.readyState < 4) {

                //aquí se puede poner una imagen de un reloj o un texto “Cargando”

            }

            else

                if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                    alert("Plana anadida");

                }

        };





        miLlamada.send(json);


    }, false);

    var div = document.getElementById("divAnadir");
    div.appendChild(nombre);
    div.appendChild(descripcion);
    div.appendChild(idCategoria);
    div.appendChild(precio);
    div.appendChild(buttonAnadir);


}

function actualizarNombre(id, nombre, descripcion, idCategoria, precio) {

    var miLlamada = new XMLHttpRequest();
    console.log(id, nombre, descripcion, idCategoria, precio)

     miLlamada.open("PUT", "http://localhost:64299/api/Planta/"+id);

     miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');


    var json = JSON.stringify({idPlanta: id, nombrePlanta: nombre, descripcion: descripcion, idCategoria: idCategoria, precio: precio});

    // Definicion estados

    miLlamada.onreadystatechange = function () {


            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                alert("Planta "+id+" actualizada")

            }

    };

    miLlamada.send(json);

}


/*function mostrar() {

    var miLlamada = new XMLHttpRequest();
    var url = "http://localhost:64299/api/Planta";
     miLlamada.open("GET", "http://localhost:64299/api/Planta");
    var divRespuesta = document.getElementById("divResultado");

    fetch(url).then(res => res.json()).then(data => {

        data.forEach(planta => {

            const div = document.createElement('div');
            div.style.display = "flex";
            const p = document.createElement('p');
            p.innerHTML = planta.nombrePlanta;


            const button = document.createElement('button');
            button.value = planta.idPlanta;
            button.textContent = "Planta " + planta.nombrePlanta;
            button.addEventListener("click", function () { eliminar(button.value) }, false);
            button.style.marginLeft = "30px";


            const inputPrecio = document.createElement('input');
            inputPrecio.id = planta.idPlanta;
            inputPrecio.style.marginLeft = "30px";

            const buttonActualizar = document.createElement('button');
            buttonActualizar.value = planta.idPlanta;
            buttonActualizar.textContent = "Actualizar " + planta.nombrePlanta;
            buttonActualizar.addEventListener("click", function () { actualizarNombre(buttonActualizar.value, inputPrecio.value, planta.descripcion, planta.idCategoria, planta.precio) }, false);
            buttonActualizar.style.marginLeft = "30px";


            div.appendChild(p)
            div.appendChild(button)
            div.appendChild(inputPrecio)
            div.appendChild(buttonActualizar)
            divRespuesta.appendChild(div)


        });


    }).catch(err => console.log(err))

    miLlamada.send();

} */


function mostrar() {

    var miLlamada = new XMLHttpRequest();
    var url = "http://localhost:64299/api/Planta";
    miLlamada.open("GET", "http://localhost:64299/api/Planta");
    var tabla = document.getElementById("default");
    var selector = document.getElementById("selector");
    var existe = false;

    fetch(url).then(res => res.json()).then(data => {

        data.forEach(planta => {

            const tr = document.createElement('tr');
            tr.className = "Datos";
            const tdIdPlanta = document.createElement('td');
            const tdNombre = document.createElement('td');
            const tdDescripcion = document.createElement('td');
            const tdPreico = document.createElement('td');
            const tdIdCategoria = document.createElement('td');
            const buttonEliminar = document.createElement('td');
            const buttonActualizarTd = document.createElement('td');

            tdIdPlanta.innerHTML = planta.idPlanta;
            tdDescripcion.innerHTML = planta.descripcion;
            tdPreico.innerHTML = planta.precio
            tdIdCategoria.innerHTML = planta.idCategoria;

            const button = document.createElement('button');
            button.value = planta.idPlanta;
            button.textContent = "Eliminar " + planta.nombrePlanta;
            button.addEventListener("click", function () { eliminar(button.value) }, false);
            button.style.marginLeft = "30px";

            const option = document.createElement('option');
            option.value = planta.idCategoria;
            option.text = planta.idCategoria;
            for (i = 0; i < selector.length && !existe; ++i) {
                if (selector.options[i].value == planta.idCategoria) {
                    existe = true;
                }
            }
            if (!existe) {
                selector.appendChild(option);
            } else {
                existe = false;
            }

            const inputPrecio = document.createElement('input');
            inputPrecio.id = planta.idPlanta;
            inputPrecio.value = planta.nombrePlanta;
            inputPrecio.style.marginLeft = "30px";

            const buttonActualizar = document.createElement('button');
            buttonActualizar.value = planta.idPlanta;
            buttonActualizar.textContent = "Actualizar " + planta.nombrePlanta;
            buttonActualizar.addEventListener("click", function () { actualizarNombre(buttonActualizar.value, inputPrecio.value, planta.descripcion, planta.idCategoria, planta.precio) }, false);
            buttonActualizar.style.marginLeft = "30px";

            tdNombre.appendChild(inputPrecio);
            buttonEliminar.appendChild(button);
            buttonActualizarTd.appendChild(buttonActualizar);
            tr.appendChild(tdIdPlanta);
            tr.appendChild(tdNombre);
            tr.appendChild(tdDescripcion);
            tr.appendChild(tdPreico);
            tr.appendChild(tdIdCategoria);
            tr.appendChild(buttonEliminar)
            tr.appendChild(buttonActualizarTd);

            tabla.appendChild(tr);




        });


    }).catch(err => console.log(err))

    miLlamada.send();

}


function filtrar() {


    var tabla = document.getElementById("default");
    var selector = document.getElementById("selector");
    document.querySelectorAll('.Datos').forEach(e => e.remove());
    var url = "http://localhost:64299/api/Planta";


    if (selector.value == "Todas") {
        document.querySelectorAll('.Datos').forEach(e => e.remove());
        mostrar();

    } else {

        fetch(url).then(res => res.json()).then(data => {

            data.forEach(planta => {

                if (selector.value == planta.idCategoria) {

                    const tr = document.createElement('tr');
                    tr.className = "Datos";

                    const tdIdPlanta = document.createElement('td');
                    const tdNombre = document.createElement('td');
                    const tdDescripcion = document.createElement('td');
                    const tdPreico = document.createElement('td');
                    const tdIdCategoria = document.createElement('td');
                    const buttonEliminar = document.createElement('td');
                    const buttonActualizarTd = document.createElement('td');

                    tdIdPlanta.innerHTML = planta.idPlanta;
                    tdDescripcion.innerHTML = planta.descripcion;
                    tdPreico.innerHTML = planta.precio
                    tdIdCategoria.innerHTML = planta.idCategoria;

                    const button = document.createElement('button');
                    button.value = planta.idPlanta;
                    button.textContent = "Eliminar " + planta.nombrePlanta;
                    button.addEventListener("click", function () { eliminar(button.value) }, false);
                    button.style.marginLeft = "30px";


                    const inputPrecio = document.createElement('input');
                    inputPrecio.id = planta.idPlanta;
                    inputPrecio.value = planta.nombrePlanta;
                    inputPrecio.style.marginLeft = "30px";

                    const buttonActualizar = document.createElement('button');
                    buttonActualizar.value = planta.idPlanta;
                    buttonActualizar.textContent = "Actualizar " + planta.nombrePlanta;
                    buttonActualizar.addEventListener("click", function () { actualizarNombre(buttonActualizar.value, inputPrecio.value, planta.descripcion, planta.idCategoria, planta.precio) }, false);
                    buttonActualizar.style.marginLeft = "30px";

                    tdNombre.appendChild(inputPrecio);
                    buttonEliminar.appendChild(button);
                    buttonActualizarTd.appendChild(buttonActualizar);
                    tr.appendChild(tdIdPlanta);
                    tr.appendChild(tdNombre);
                    tr.appendChild(tdDescripcion);
                    tr.appendChild(tdPreico);
                    tr.appendChild(tdIdCategoria);
                    tr.appendChild(buttonEliminar)
                    tr.appendChild(buttonActualizarTd);

                    tabla.appendChild(tr);

                }


            });


        }).catch(err => console.log(err))


    }

}