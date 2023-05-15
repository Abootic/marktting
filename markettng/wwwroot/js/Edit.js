import { routting } from "./routting.js";
export function GetEditingObjById(id, url) {



   
    let data = { "id": id };
    jQuery.ajax({
        type: 'GET',
        url: url,
        data: data,
        cache: false,
        beforeSend: function () {


            $("#offcanvasEdit").html("  <div style='width: 8rem; height: 8rem; position: fixed;  left: 39%; top: 44%;font-size: 2rem;' class='spinner-border text-info' role='status'> </div>");
        },
        success: function (repo) {
            $("#offcanvasEdit").html(repo);
         

        },



        error: function (ex) {

            console.log( ex.responseText);
            
        }
    });
}


export default function Edit(url, tagId,redirect) {
   
    let data = new FormData(document.getElementById(tagId));
    jQuery.ajax({
        method: "post",
        url: url,
        data: data,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $(".send-btn").prop("disabled", true);
            $(".send-btn").html("<span class='spinner-border spinner-border-sm' role='status' aria-hidden='true'> </span>Loading...");
          
        },
        success: function (sucess) {
            $(".send-btn").prop("disabled", false);
            $(".send-btn").html("تعديل");
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Your work has been saved',
                showConfirmButton: false,
                timer: 1500
            });
          
            routting(redirect, true);
        
        },
        error: function (er) {

            $(".send-btn").prop("disabled", false);
            $(".send-btn").html("تعديل");

            console.log(er.responseText);
          
        }

    });
  
}

///////////////