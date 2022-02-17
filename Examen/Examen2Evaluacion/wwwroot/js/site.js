 window.onload = inicializaEventos;


function inicializaEventos() {

    //En cuanto carga la pagian mostramos la tabla
    mostrar();
    //Asociamos al boton de ver plantas la fucnion
    document.getElementById("Ver").addEventListener("click", mostrarPlantas, false);
   
}



function mostrar() {

    var url = "http://localhost:64299/api/Categoria";
    var tabla = document.getElementById("default");

   

    fetch(url).then(res => res.json()).then(data => {

        data.forEach(categoria => {

            const tr = document.createElement('tr');
            const tdNombre = document.createElement('td');
            const radio = document.createElement('input');

            tdNombre.innerHTML = categoria.name;
            radio.type = "checkbox"

            //Para el boton asociamos una clase la id de la categoria y el nombre(ya que si no despues tendriamos que llamar a la api para saber el nombre de una categoria)
            radio.className = "radiogroup"
            radio.id = categoria.id;
            radio.value = categoria.name;
        

            tr.appendChild(tdNombre);
            tr.appendChild(radio);

            tabla.appendChild(tr);


        });


    }).catch(err => console.log(err))

}


function mostrarPlantas() {

    hayAlgoSeleccionado = false;

    //Elinamos los datos existentes
    document.querySelectorAll('.Plantas').forEach(e => e.remove());

    //Buscamos el elemento que contiene los datos
    const div = document.getElementById("verPlantas");

    //Para cada elemento que tenga la clave radiogroup osea todos los botones
    document.querySelectorAll('.radiogroup').forEach(e => {

        //Si esta seleccionado
        if (e.checked) {


            hayAlgoSeleccionado = true;
            //Contenedor para la informacion de una categoria
            const divContenedor = document.createElement('div');
            //Como ya hay elementos que tienen la id de la categoria vamos a diferenciar
            divContenedor.id = e.id + "C";
            //Asociamos una clase para despues borrar todos los contenedores
            divContenedor.className = "Plantas";
            //Nombre de la categoria
            const p = document.createElement('p');
            //Ponemos el value del radio group actual recordando que el value era el nombre, si no lo hubieramos hecho tendriamos que llamar a la api otra vez
            p.innerHTML = e.value;
            divContenedor.appendChild(p);
            div.appendChild(divContenedor);

            //Esta api te la todas las plantas de una categoria
            var url = "http://localhost:64299/api/Planta/"+e.id;

             fetch(url).then(res => res.json()).then(data => {

                data.forEach(planta => {

                    //Creamos un div para cada planta que haya, eso es para que la informacion salga en horizontal
                    const divPlantas = document.createElement('div');
                    divPlantas.style.display = "flex";

                    //Asociamos los datos de la planta
                    const p = document.createElement('p');
                    p.innerHTML = planta.nombrePlanta;
                    const p1 = document.createElement('p');
                    p1.style.marginLeft = "30px";
                    p1.innerHTML = planta.precio + "$";

                    divPlantas.appendChild(p);
                    divPlantas.appendChild(p1);

                    //El div con los datos de la planta lo metemos en el contenedor de la categoria correspondiente
                    document.getElementById(e.id + "C").appendChild(divPlantas);


                   

                });


                 const hr = document.createElement('hr');
                 divContenedor.appendChild(hr);


            }).catch(err => console.log(err))


        }

    });

    if (!hayAlgoSeleccionado) {
        alert("Fernando, tienes que seleccionar algo");
    }

}