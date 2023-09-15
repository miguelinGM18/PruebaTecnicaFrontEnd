$(document).ready(function() {
    $('#btnEnviar').click(function(e) {
        e.preventDefault(); // Evita que el formulario se envíe de forma predeterminada
        
        // Obtén los datos del formulario
        var formData = {
            nombre: sessionStorage.getItem('Nombre'),
            segundoNombre: sessionStorage.getItem('SegundoNombre'),
            apellidoPaterno: sessionStorage.getItem('ApellidoPaterno'),
            apellidoMaterno: sessionStorage.getItem('ApellidoMaterno'),
            fechaNacimiento: sessionStorage.getItem('FechaNacimiento'),
            email: sessionStorage.getItem('Email'),
            telefono: sessionStorage.getItem('Telefono')  //generar tu request            
        };
        
        // Convierte los datos del formulario a JSON
        var jsonData = JSON.stringify(formData);

        //Icono de carga
        $("#spinner").show();
        
        // Realiza la solicitud a la API usando $.ajax()
        $.ajax({
            type: 'POST', // O el método HTTP que necesites
            url: 'https://localhost:7054/api/Usuarios', // URL de la API
            data: jsonData, // Datos en formato JSON
            contentType: 'application/json', // Tipo de contenido
            success: function(response) {
                // Manejar la respuesta exitosa de la API aquí
                $("#spinner").hide();
                alert("Te has registrado con exito");
                //console.log(response);
            },
            error: function(error) {
                // Manejar errores de la API aquí
                $("#spinner").hide();
                $("#miModal").modal("show"); // Abre el modal
                setTimeout(function() {
                    $("#miModal").modal("hide");
                  }, 5000);
            }
        });
    });

        //Validar campos "Nombre"
    $('#divNombre').children("input").blur(function(){        
        let nombre = '';        
        let completado = true;
        $('#divNombre').children("input").each(function(index,input){       
            if($(input).val() === '')
            completado = false;                                                                                                          
        });
        if(completado){
            $('#divNombre').children("input").each(function(index,input){       
                $(input).prop('disabled', true);  
                nombre = nombre+' '+$(input).val();
                switch(index){
                    case 0:
                        sessionStorage.setItem("Nombre",$(input).val());                        
                        break;
                    case 1:
                        sessionStorage.setItem("SegundoNombre",$(input).val());
                        break;
                    case 2:
                        sessionStorage.setItem("ApellidoPaterno",$(input).val());
                        break;
                    case 3:
                        sessionStorage.setItem("ApellidoMaterno",$(input).val());
                        break;
                }
            });            
            $('#lblNombre').append(nombre);
            $('#divResultName').css({'color':'#F8F9F9','background-color': '#F715F7'});            
        }
        return;
    });
        //Validar campos "fecha de nacimiento"
    $('#divFechaNacimiento').children("input").blur(function(){        
        let fechaNacimiento = '';        
        let completado = true;
        $('#divFechaNacimiento').children("input").each(function(index,input){       
            if($(input).val() === '')
            completado = false; 
        });
        if(completado){
            $('#divFechaNacimiento').children("input").each(function(index,input){       
                $(input).prop('disabled', true);  
            });
            fechaNacimiento = $('#anio').val()+'-'+$('#mes').val()+'-'+$('#dia').val();
            sessionStorage.setItem("FechaNacimiento",fechaNacimiento);
            $('#lblFechaNacimiento').append(fechaNacimiento);
            $('#divResultFechaNacimiento').css({'color':'#F8F9F9','background-color': '#F715F7'});            
        }
        return;
    });
        //validar campos "Datos del contacto"
    $('#divDatosContacto').children("input").blur(function(){        
        let email = '';        
        let telefono = '';        
        let completado = true;
        $('#divDatosContacto').children("input").each(function(index,input){       
            if($(input).val() === '')
            completado = false;                                                                                                          
        });
        if(completado){
            $('#divDatosContacto').children("input").each(function(index,input){       
                $(input).prop('disabled', true);  
            });
            email = $('#email').val();
            telefono = $('#phone').val();

            sessionStorage.setItem("Email",email);
            sessionStorage.setItem("Telefono",telefono);

            $('#lblCorreo').append(email);
            $('#lblTelefono').append(telefono);
            $('#divResultContacto').css({'color':'#F8F9F9','background-color': '#F715F7'});            
        }
        return;
    });
    
});
